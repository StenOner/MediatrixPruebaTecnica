using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatrixPruebaTecnica.Entities.Interfaces;
using MediatrixPruebaTecnica.Entities.POCOs;
using MediatrixPruebaTexnica.DTOs.AuthDTOs;
using MediatrixPruebaTexnica.UseCasesPorts.AuthUseCasesPorts.Login;
using MediatrixPruebaTexnica.UseCasesPorts.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MediatrixPruebaTexnica.UseCases.AuthUseCases
{
    public class LoginInteractor(IUsuarioRepository usuarioRepository, ILoginOutputPort loginOutputPort, IUnitOfWork unitOfWork, IConfiguration configuration) : ILoginInputPort
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly ILoginOutputPort _outputPort = loginOutputPort;
        private readonly IConfiguration _configuration = configuration;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(LoginRequestDto dto)
        {
            var usuario = await _usuarioRepository.GetByNombreUsuarioAsync(dto.NombreUsuario);

            if (usuario == null || !VerifyPassword(dto.Password, usuario.PasswordHash))
            {
                await _outputPort.Handle(
                    Result<LoginResponseDto>.FailureResult("Credenciales inválidas")
                    );

                return;
            }

            if (!usuario.Activo)
            {
                await _outputPort.Handle(
                    Result<LoginResponseDto>.FailureResult("Usuario inactivo")
                    );

                return;
            }

            var token = GenerateJwtToken(usuario);
            var expiracion = DateTime.UtcNow.AddHours(8);

            var response = new LoginResponseDto
            {
                Token = token,
                NombreUsuario = usuario.NombreUsuario,
                Rol = usuario.Rol.Nombre,
                Expiracion = expiracion
            };

            await _outputPort.Handle(
                Result<LoginResponseDto>.SuccessResult(response)
                );
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                new Claim(ClaimTypes.Role, usuario.Rol.Nombre)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}