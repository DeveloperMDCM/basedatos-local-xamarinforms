-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 04-11-2020 a las 15:18:53
-- Versión del servidor: 10.4.14-MariaDB
-- Versión de PHP: 7.4.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `comidas`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `app`
--

CREATE TABLE `app` (
  `id` int(11) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `token` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `app`
--

INSERT INTO `app` (`id`, `nombre`, `token`) VALUES
(1, 'sair', 'token123');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `comidas`
--

CREATE TABLE `comidas` (
  `IDComida` int(11) NOT NULL,
  `NombreComida` varchar(30) NOT NULL,
  `Categoria` varchar(30) NOT NULL,
  `Descripcion` text NOT NULL,
  `Costo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `comidas`
--

INSERT INTO `comidas` (`IDComida`, `NombreComida`, `Categoria`, `Descripcion`, `Costo`) VALUES
(1, 'Desgranado Mixto', 'Desgranados', 'Queso mozarela, papas a la francesa, salsas', 12000),
(2, 'Desgranado Alfa', 'Desgranados', 'papas, queso doble crema, queso mozarela, carne, pollo, cerdo', 15000),
(3, 'desgranado', 'desgrando', 'queso, papas', 120000),
(4, 'sair', 'sair', 'sair', 2000),
(5, 'pizza', 'pizza', 'masa, queso, jamon', 5000),
(6, 'Chori perro', 'perros', 'pan, chorizo, papita', 9000),
(7, 'perro', 'perro', 'pan', 9000),
(8, 'Salchipapa', 'salchipapa', 'papitas, papas a la francesa, ', 8000),
(9, 'Desgrando', 'Desgrandos', 'papas a la francesa, jamon, queso.', 5000);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `app`
--
ALTER TABLE `app`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `comidas`
--
ALTER TABLE `comidas`
  ADD PRIMARY KEY (`IDComida`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `app`
--
ALTER TABLE `app`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `comidas`
--
ALTER TABLE `comidas`
  MODIFY `IDComida` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
