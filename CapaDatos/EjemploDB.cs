using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    class EjemploDB
    {
        //No me acorda como agregar un script
        // tengo sueño 

////    create database DB_SISTEMA_ADMINISTRATIVO;
////USE DB_SISTEMA_ADMINISTRATIVO;




////CREATE TABLE Propietarios(
////    Id INT PRIMARY KEY identity(1,1),
////    Nombre VARCHAR(50) NOT NULL,
////    Apellido VARCHAR(50) NOT NULL,
////	NumeroDocumento VARCHAR(15) UNIQUE  NOT NULL,
////    Email VARCHAR(100) UNIQUE NOT NULL,
////	Telefono VARCHAR(10) UNIQUE NOT NULL,
////	Foto  VARCHAR(MAX) NULL,
////);

////CREATE TABLE Edificios (
////    Id INT PRIMARY KEY identity(1,1),
////    Nombre VARCHAR(100) NOT NULL,
////    Direccion VARCHAR(255) NOT NULL
////);

////CREATE TABLE Unidad (
////    Id INT PRIMARY KEY  identity(1,1),
////    NumUnidad INT NOT NULL,
////    Piso INT NOT NULL,
////    Porcentaje DECIMAL(5, 2) NOT NULL,
////    GastosMensuales DECIMAL(10, 2) NOT NULL,
////    Edificio_Id INT,
////    Propietario_Id INT,
////    FOREIGN KEY (Edificio_Id) REFERENCES Edificios(Id),
////    FOREIGN KEY (Propietario_Id) REFERENCES Propietarios(Id)
////);
////CREATE TABLE TipoEgresos
////(
////	Id INT PRIMARY KEY identity(1,1),
////    Pago_Portero DECIMAL NOT NULL,
////    Cargas_Sociales DECIMAL NOT NULL, 
////    Suterh DECIMAL NOT NULL,
////	Fateryh DECIMAL NOT NULL,
////	Seracarh DECIMAL NOT NULL,
////	Edet DECIMAL NOT NULL,
////	Sat DECIMAL NOT NULL,
////    Honorarios_Contador DECIMAL NOT NULL,
////    Honorarios_Administrador DECIMAL NOT NULL,
////    Salud_Publica DECIMAL NOT NULL,
////    Seguro DECIMAL NOT NULL,
////	GastosBancarios DECIMAL NOT NULL,
////    Fumigacion DECIMAL NOT NULL,
////    Remitos DECIMAL NOT NULL,
////    Prod_Limpieza DECIMAL NOT NULL,
////    Gastos_Varios DECIMAL NOT NULL
////);



////CREATE TABLE Egresos
////(
////    Id int PRIMARY KEY identity(1,1),
////    Descripcion TEXT NOT NULL,
////    Monto DECIMAL NOT NULL,
////    Fecha DATE NOT NULL,
////    Id_Tipo_Egreso INT NOT NULL,
////    Id_Edificio INT,
////    FOREIGN KEY (Id_Tipo_Egreso) REFERENCES TipoEgresos(Id),
////    FOREIGN KEY (Id_Edificio) REFERENCES Edificios(Id)
////);




////CREATE TABLE Usuarios (
////    Id INT PRIMARY KEY identity(1,1),
////    Nombre VARCHAR(100) NOT NULL,
////    Apellido VARCHAR(100) NOT NULL,
////    Email VARCHAR(150) NOT NULL UNIQUE,
////	Foto  VARCHAR(MAX) NULL,
////    Clave VARCHAR(150) NOT NULL, 
////	Acceso VARCHAR(150) NOT NULL, 

////);
  }
}
