using MediatrixPruebaTecnica.Entities.Bases;
using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTexnica.DTOs.RegistroPagoDTOs;
using MediatrixPruebaTexnica.UseCases.RegistroPagoUseCases;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.CreateRegistroPago;
using MediatrixPruebaTexnica.UseCasesPorts.RegistroPagoUseCasesPorts.GetReportePago;
using Moq;
using NUnit.Framework;

namespace MediatrixPruebaTecnica.Tests.RegistroPagoTests
{
    [TestFixture]
    public class RegistroPagoInteractorsTests
    {
        private class TestEmpleado : Empleado
        {
            private readonly decimal _pagoSemanal;
            public TestEmpleado(Guid id, string primerNombre, string apellidoPaterno, decimal pagoSemanal)
            {
                Id = id;
                PrimerNombre = primerNombre;
                ApellidoPaterno = apellidoPaterno;
                NumeroSeguroSocial = "TEST-SSN";
                Departamento = "TestDept";
                Activo = true;
                RegistrosPagos = [];
                FechaCreacion = DateTime.UtcNow;
                _pagoSemanal = pagoSemanal;
            }

            public override decimal CalcularPagoSemanal() => _pagoSemanal;
        }

        [Test]
        public async Task CreateRegistroPagoInteractor_WhenEmpleadoNotFound_ReturnsFailureResult()
        {
            var registroRepo = new Mock<IRegistroPagoRepository>();
            var empleadoRepo = new Mock<IEmpleadoRepository>();
            var outputPort = new Mock<ICreateRegistroPagoOutputPort>();
            var unitOfWork = new Mock<IUnitOfWork>();

            empleadoRepo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                        .ReturnsAsync((Empleado?)null);

            Result<RegistroPagoDto>? captured = null;
            outputPort.Setup(o => o.Handle(It.IsAny<Result<RegistroPagoDto>>()))
                      .Callback<Result<RegistroPagoDto>>(r => captured = r)
                      .Returns(Task.CompletedTask);

            var interactor = new CreateRegistroPagoInteractor(registroRepo.Object, empleadoRepo.Object, outputPort.Object, unitOfWork.Object);

            var dto = new CreateRegistroPagoDto
            {
                EmpleadoId = Guid.NewGuid(),
                PeriodoInicio = DateTime.UtcNow.AddDays(-7),
                PeriodoFin = DateTime.UtcNow,
                Deducciones = 10m,
                Observaciones = "Test"
            };

            // Act
            await interactor.Handle(dto);

            // Assert
            outputPort.Verify(o => o.Handle(It.IsAny<Result<RegistroPagoDto>>()), Times.Once);
            Assert.NotNull(captured);
            Assert.IsFalse(captured!.Success);
            Assert.AreEqual("Empleado no encontrado", captured.ErrorMessage);
        }

        [Test]
        public async Task CreateRegistroPagoInteractor_WhenEmpleadoExists_AddsRegistroAndReturnsSuccess()
        {
            // Arrange
            var registroRepo = new Mock<IRegistroPagoRepository>();
            var empleadoRepo = new Mock<IEmpleadoRepository>();
            var outputPort = new Mock<ICreateRegistroPagoOutputPort>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var empleadoId = Guid.NewGuid();
            var pagoSemanal = 1000m;
            var empleado = new TestEmpleado(empleadoId, "Juan", "Perez", pagoSemanal);

            empleadoRepo.Setup(r => r.GetByIdAsync(empleadoId)).ReturnsAsync(empleado);
            registroRepo.Setup(r => r.AddAsync(It.IsAny<RegistroPago>())).Returns(Task.CompletedTask);
            unitOfWork.Setup(u => u.SaveChangesAsync()).ReturnsAsync(1);

            Result<RegistroPagoDto>? captured = null;
            outputPort.Setup(o => o.Handle(It.IsAny<Result<RegistroPagoDto>>()))
                      .Callback<Result<RegistroPagoDto>>(r => captured = r)
                      .Returns(Task.CompletedTask);

            var interactor = new CreateRegistroPagoInteractor(registroRepo.Object, empleadoRepo.Object, outputPort.Object, unitOfWork.Object);

            var dto = new CreateRegistroPagoDto
            {
                EmpleadoId = empleadoId,
                PeriodoInicio = DateTime.UtcNow.AddDays(-7),
                PeriodoFin = DateTime.UtcNow,
                Deducciones = 150m,
                Observaciones = "Payroll test"
            };

            // Act
            await interactor.Handle(dto);

            // Assert
            registroRepo.Verify(r => r.AddAsync(It.IsAny<RegistroPago>()), Times.Once);
            unitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
            outputPort.Verify(o => o.Handle(It.IsAny<Result<RegistroPagoDto>>()), Times.Once);

            Assert.NotNull(captured);
            Assert.IsTrue(captured!.Success);
            Assert.NotNull(captured.Data);
            Assert.AreEqual(pagoSemanal, captured.Data!.MontoBruto);
            Assert.AreEqual(dto.Deducciones, captured.Data.Deducciones);
            Assert.AreEqual(pagoSemanal - dto.Deducciones, captured.Data.MontoNeto);
            Assert.AreEqual(dto.EmpleadoId, captured.Data.EmpleadoId);
        }

        [Test]
        public async Task GetReportePagoInteractor_ReturnsReporteWithCorrectTotals()
        {
            // Arrange
            var registroRepo = new Mock<IRegistroPagoRepository>();
            var outputPort = new Mock<IGetReportePagoOutputPort>();

            var inicio = new DateTime(2025, 1, 1);
            var fin = new DateTime(2025, 1, 31);

            var pagos = new List<RegistroPago>
            {
                new() { Id = Guid.NewGuid(), EmpleadoId = Guid.NewGuid(), FechaPago = inicio.AddDays(1), PeriodoInicio = inicio, PeriodoFin = inicio.AddDays(7), MontoBruto = 100m, Deducciones = 10m, MontoNeto = 90m, FechaCreacion = DateTime.UtcNow },
                new() { Id = Guid.NewGuid(), EmpleadoId = Guid.NewGuid(), FechaPago = inicio.AddDays(8), PeriodoInicio = inicio.AddDays(8), PeriodoFin = inicio.AddDays(14), MontoBruto = 200m, Deducciones = 20m, MontoNeto = 180m, FechaCreacion = DateTime.UtcNow }
            };

            registroRepo.Setup(r => r.GetPagosPorPeriodoAsync(inicio, fin)).ReturnsAsync(pagos);

            Result<ReportePagosDto>? captured = null;
            outputPort.Setup(o => o.Handle(It.IsAny<Result<ReportePagosDto>>()))
                      .Callback<Result<ReportePagosDto>>(r => captured = r)
                      .Returns(Task.CompletedTask);

            var interactor = new GetReportePagoInteractor(registroRepo.Object, outputPort.Object);

            // Act
            await interactor.Handle(inicio, fin);

            // Assert
            outputPort.Verify(o => o.Handle(It.IsAny<Result<ReportePagosDto>>()), Times.Once);
            Assert.NotNull(captured);
            Assert.IsTrue(captured!.Success);
            Assert.NotNull(captured.Data);

            var reporte = captured.Data!;
            Assert.AreEqual(inicio, reporte.FechaInicio);
            Assert.AreEqual(fin, reporte.FechaFin);
            Assert.AreEqual(2, reporte.Pagos.Count);
            Assert.AreEqual(pagos.Sum(p => p.MontoBruto), reporte.TotalBruto);
            Assert.AreEqual(pagos.Sum(p => p.Deducciones), reporte.TotalDeducciones);
            Assert.AreEqual(pagos.Sum(p => p.MontoNeto), reporte.TotalNeto);
        }
    }
}
