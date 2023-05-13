USE master; 
Go

CREATE DATABASE DMV_API
Go

USE DMV_API
GO


--------------Driver Table-----------------------------
Create Table Drivers (
DriverID varchar (20) NOT NUll,
DFirstName varchar (20) NOT NULL,
DLastName varchar(20) NOT NULL,
DSSN varchar (20) NOT NULL,
DAddress varchar (50) NOT NULL,
DCity varchar (20) NOT NULL,
DState varchar (20) NOT NULL,
DZip varchar (20) NOT NULL,
PRIMARY KEY (DriverID)
);


INSERT INTO Drivers(DriverID, DFirstName, DLastName, DSSN, DAddress, DCity, DState, DZip) VALUES
('D00001','Laura','Werner','555-55-5555','234 Real Adress', 'Saint Cloud','MN','56303'),
('D00002','Laura','smith','555-54-5565','23f Real Adress', 'Saint Cloud','MN','56303'),
('D00003','Mick','Ver','555-53-5525','2344 Rel Adress', 'Cold Spring','MN','56320'),
('D00004','Jane','Wenr','545-75-5965','201 Real Address', 'Saint Cloud','MN','56303'),
('D00005','John','Buck','125-55-5529','89 Rl Address Drive', 'Saint Cloud','MN','56301'),
('D00006','George','Felicity','415-55-5595','8962 Real Address', 'Saint Cloud','MN','56303'),
('D00007','Jane','Felicity','415-55-1595','8962 Real Address', 'Saint Cloud','MN','56303'),
('D00008','Gee','Whiz','415-55-5155','8962 Real Adress Drive', 'Saint Cloud','MN','56301'),
('D00009','George','Felicity','415-55-5189','125 Real Adress', 'Saint Cloud','MN','56301'),
('D00010','Mike','Bar','415-55-1585','8962 Reallll Adress', 'Saint Cloud','MN','56303')


-----------------------------------------------------------------------------


----------------------Vehicles table----------------------
Create Table Vehicles (
VehicleID varchar(20) NOT NULL,
VehicleType varchar (20) NOT NULL,
PRIMARY KEY (VehicleID)
);


INSERT INTO Vehicles(VehicleID, VehicleType) VALUES
('V00001','SUV'),
('V00002','Station Wagon'),
('V00003','Van'),
('V00004','Sedan'),
('V00005','Convertible'),
('V00006','Minivan'),
('V00007','Eletric Vehicle'),
('V00008','Limousine'),
('V00009','Hatchback'),
('V00010','Motorcycle')

----------------------------------------------------------------

-----------------Licenses table---------------------

Create Table Licenses (
LicenseID varchar (20) NOT NULL,
DriverID varchar(20) FOREIGN KEY REFERENCES Drivers(DriverID),
VehicleID varchar(20) FOREIGN KEY REFERENCES Vehicles(VehicleID),
PRIMARY KEY (LicenseID)
);


INSERT INTO Licenses(LicenseID, DriverID,VehicleID) VALUES
('L00001', 'D00001', 'V00001'),
('L00002', 'D00002', 'V00002'),
('L00003', 'D00003', 'V00003'),
('L00004', 'D00004', 'V00004'),
('L00005', 'D00005', 'V00005'),
('L00006', 'D00006', 'V00006'),
('L00007', 'D00007', 'V00007'),
('L00008', 'D00008', 'V00008'),
('L00009', 'D00009', 'V00009'),
('L00010', 'D00010', 'V00010'),
('L00011', 'D00010', 'V00001')


---------------------------------------------------------------

------------DMV table---------------------------------------------

Create Table DMV (
DMVID varchar(20) NOT NULL,
DMVUserName varchar(50) NOT NULL,
DMVPassword varchar(20) NOT NULL,
PRIMARY KEY (DMVID)
);


INSERT INTO DMV(DMVID, DMVUserName, DMVPassword) VALUES
('DM0001','DMV1','DMV1'),
('DM0002','DMV2','DMV2'),
('DM0003','DMV3','DMV3'),
('DM0004','DMV4','DMV4'),
('DM0005','DMV5','DMV5'),
('DM0006','DMV6','DMV6'),
('DM0007','DMV7','DMV7'),
('DM0008','DMV8','DMV8'),
('DM0009','DMV9','DMV9'),
('DM0010','DMV10','DMV10')

---------------------------------------------------------------

---------------------License Issuer linking table---------------------------
Create Table LicenseIssuer (
DMVID varchar(20) FOREIGN KEY REFERENCES DMV(DMVID),
LicenseID varchar(20) FOREIGN KEY REFERENCES Licenses(LicenseID),
Primary Key (DMVID, LicenseID)
);


INSERT INTO LicenseIssuer(LicenseID,DMVID) VALUES
('L00001', 'DM0001'),
('L00002', 'DM0002'),
('L00003', 'DM0003'),
('L00004', 'DM0004'),
('L00005', 'DM0005'),
('L00006', 'DM0006'),
('L00007', 'DM0007'),
('L00008', 'DM0008'),
('L00009', 'DM0009'),
('L00010', 'DM0010')

------------------------------------------------------------


---------------Law Enforcement Table-------------------------------------------

Create Table LawEnforcement (
LawEnID varchar(20) NOT NULL,
LEUserName varchar(50) NOT NULL,
LEPassword varchar(20) NOT NULL,
PRIMARY KEY (LawEnID)
);



INSERT INTO LawEnforcement(LawEnID,LEUserName,LEPassword) VALUES
('LE0001','LE1','LE1'),
('LE0002','LE2','LE2'),
('LE0003','LE3','LE3'),
('LE0004','LE4','LE4'),
('LE0005','LE5','LE5'),
('LE0006','LE6','LE6'),
('LE0007','LE7','LE7'),
('LE0008','LE8','LE8'),
('LE0009','LE9','LE9'),
('LE0010','LE10','LE10')



--------------------------------------------------------------------------


------------------------------Infraction Info Table

Create TABLE InfractionInfo (
IInfoID varchar(20) NOT NULL,
IType varchar (50) NOT NULL,
IFine INT NOT NULL,
PRIMARY KEY (IInfoID)
);

INSERT INTO InfractionInfo(IInfoID, IType, IFine) VALUES
('II0001', 'Speeding', '20'),
('II0002', 'Running A Red Light', '30'),
('II0003', 'Seat Belt Violation', '10'),
('II0004', 'Tail Light out', '20'),
('II0005', 'Driving Without Insurance', '70')


-------------------------------------------------------



------------------Infractions table------------------------------------------


Create Table Infractions (
InfractionID varchar(20) NOT NULL,
IInfoID varchar(20) FOREIGN KEY REFERENCES InfractionInfo(IInfoID),
LicenseID varchar(20) FOREIGN KEY REFERENCES Licenses(LicenseID),
LawEnID varchar(20) FOREIGN KEY REFERENCES LawEnforcement(LawEnID)
PRIMARY KEY (InfractionID)
);


INSERT INTO Infractions(InfractionID, IInfoID, LicenseID, LawEnID) VALUES
('I00001', 'II0001', 'L00001', 'LE0001'),
('I00002', 'II0002', 'L00002', 'LE0002'),
('I00003', 'II0003', 'L00003', 'LE0003'),
('I00004', 'II0004', 'L00004', 'LE0004'),
('I00005', 'II0005', 'L00005', 'LE0005'),
('I00006', 'II0001', 'L00006', 'LE0006'),
('I00007', 'II0001', 'L00007', 'LE0007'),
('I00008', 'II0002', 'L00008', 'LE0008'),
('I00009', 'II0001', 'L00009', 'LE0009'),
('I00010', 'II0001', 'L00010', 'LE0009'),
('I00011', 'II0005', 'L00010', 'LE0010')



----------------------------------------------------------------------------
