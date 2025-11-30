USE MediatrixPruebaTecnica;
GO

-- =============================================
-- 1. INSERTAR ROLES
-- =============================================

-- Verificar si los roles ya existen, si no, insertarlos
IF NOT EXISTS (SELECT 1 FROM Roles WHERE Id = '11111111-1111-1111-1111-111111111111')
BEGIN
    INSERT INTO Roles (Id, Nombre, Descripcion, FechaCreacion)
    VALUES (
        '11111111-1111-1111-1111-111111111111',
        'Admin',
        'Administrador',
        GETUTCDATE()
    );
    PRINT 'Rol Admin creado exitosamente';
END
ELSE
BEGIN
    PRINT 'Rol Admin ya existe';
END

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Id = '22222222-2222-2222-2222-222222222222')
BEGIN
    INSERT INTO Roles (Id, Nombre, Descripcion, FechaCreacion)
    VALUES (
        '22222222-2222-2222-2222-222222222222',
        'Usuario',
        'Usuario',
        GETUTCDATE()
    );
    PRINT 'Rol Usuario creado exitosamente';
END
ELSE
BEGIN
    PRINT 'Rol Usuario ya existe';
END

GO

-- =============================================
-- 2. INSERTAR USUARIOS
-- =============================================

-- Usuario 1: Administrador
-- Contraseña: admin
-- Hash BCrypt generado para "admin"
IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE NombreUsuario = 'admin')
BEGIN
    INSERT INTO Usuarios (Id, NombreUsuario, PasswordHash, RolId, Activo, FechaCreacion)
    VALUES (
        '33333333-3333-3333-3333-333333333333',
        'admin',
        '$2a$11$hzEWzXTX5nQelfKygTeyjO/SgS13BpkMaDycKTAVVxfjQZUhS98De',
        '11111111-1111-1111-1111-111111111111',
        1,
        GETUTCDATE()
    );
    PRINT 'Usuario admin creado exitosamente';
END
ELSE
BEGIN
    PRINT 'Usuario admin ya existe';
END

-- Usuario 2: Usuario Regular 1
-- Contraseña: user
-- Hash BCrypt generado para "user"
IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE NombreUsuario = 'usuario1')
BEGIN
    INSERT INTO Usuarios (Id, NombreUsuario, PasswordHash, RolId, Activo, FechaCreacion)
    VALUES (
        '44444444-4444-4444-4444-444444444444',
        'usuario1',
        '$2a$11$7Lz1nJepmYjS.HRvRCHMiu2GSeNMXr5DraYcHAycLfVT43n1uIjk.',
        '22222222-2222-2222-2222-222222222222',
        1,
        GETUTCDATE()
    );
    PRINT 'Usuario usuario1 creado exitosamente';
END
ELSE
BEGIN
    PRINT 'Usuario usuario1 ya existe';
END

-- Usuario 3: Usuario Regular 2
-- Contraseña: user
-- Hash BCrypt generado para "user"
IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE NombreUsuario = 'usuario2')
BEGIN
    INSERT INTO Usuarios (Id, NombreUsuario, PasswordHash, RolId, Activo, FechaCreacion)
    VALUES (
        '55555555-5555-5555-5555-555555555555',
        'usuario2',
        '$2a$11$7Lz1nJepmYjS.HRvRCHMiu2GSeNMXr5DraYcHAycLfVT43n1uIjk.',
        '22222222-2222-2222-2222-222222222222',
        1,
        GETUTCDATE()
    );
    PRINT 'Usuario usuario2 creado exitosamente';
END
ELSE
BEGIN
    PRINT 'Usuario usuario2 ya existe';
END

GO

-- =============================================
-- 3. VERIFICAR DATOS INSERTADOS
-- =============================================

PRINT '';
PRINT '=============================================';
PRINT 'RESUMEN DE DATOS INSERTADOS';
PRINT '=============================================';
PRINT '';

-- Mostrar roles
PRINT 'ROLES:';
SELECT 
    Nombre,
    Descripcion,
    FechaCreacion
FROM Roles
ORDER BY Nombre;

PRINT '';

-- Mostrar usuarios
PRINT 'USUARIOS:';
SELECT 
    u.NombreUsuario,
    r.Nombre AS Rol,
    CASE WHEN u.Activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado,
    u.FechaCreacion
FROM Usuarios u
INNER JOIN Roles r ON u.RolId = r.Id
ORDER BY r.Nombre DESC, u.NombreUsuario;