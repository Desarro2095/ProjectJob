CREATE DATABASE DbJob
GO

USE DbJob
GO

CREATE TABLE Degree(
	DegreeId INT PRIMARY KEY IDENTITY,
	DegreeDescription VARCHAR(100)
)

CREATE TABLE Users(
	UserId INT PRIMARY KEY IDENTITY,
	NameUser VARCHAR(50),
	Email VARCHAR(50),
	Phone VARCHAR(10),
	UserPassword VARCHAR(100),
	DegreeId INT,
	FOREIGN KEY (DegreeId) REFERENCES Degree(DegreeId)
)

CREATE TABLE Industry(
	IndustryId INT PRIMARY KEY IDENTITY,
	IndustryDescription VARCHAR(100)
)

CREATE TABLE Employer(
	EmployerId INT PRIMARY KEY IDENTITY,
	EmployerUser VARCHAR(50),
	Email VARCHAR(50),
	Phone VARCHAR(10),
	CurrentEmployee INT,
	EmployerPassword VARCHAR(100),
	IndustryId INT,
	FOREIGN KEY (IndustryId) REFERENCES Industry(IndustryId)
)

CREATE TABLE WorkExperience(
	WorkExperienceId INT PRIMARY KEY IDENTITY,
	WorkPlace VARCHAR(100),
	Years INT,
	UserId INT
	FOREIGN KEY (UserId) REFERENCES Users(UserId)
)

CREATE TABLE Offer(
	OfferId INT PRIMARY KEY IDENTITY,
	OfferDescription VARCHAR(100),
	CurrentVacancy INT,
	EmployerId INT,
	FOREIGN KEY (EmployerId) REFERENCES Employer(EmployerId)
)

CREATE TABLE OfferApply(
	UserId INT,
	OfferId INT,
	FOREIGN KEY (UserId) REFERENCES Users(UserId),
	FOREIGN KEY (OfferId) REFERENCES Offer(OfferId),
	PRIMARY KEY(UserId, OfferId)
)