USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [PruebaAgencia]    Script Date: 3/01/2022 2:07:27 p. m. ******/
CREATE LOGIN [PruebaAgencia] WITH PASSWORD=N'I8s55I0SCZPHSipQkSteII0aNSNdxCe1Ang32WOrblg=', DEFAULT_DATABASE=[PruebaAgencia], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [PruebaAgencia] DISABLE
GO


