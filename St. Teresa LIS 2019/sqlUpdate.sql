ALTER TABLE PATIENT ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE PATIENT ADD CONSTRAINT [PK_PATIENT] primary key (ID)

GO


ALTER TABLE CLIENT ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE CLIENT ADD CONSTRAINT [PK_CLIENT] primary key (ID)

GO

ALTER TABLE DOCTOR ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE DOCTOR ADD CONSTRAINT [PK_DOCTOR] primary key (ID)

GO

ALTER TABLE result ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE result ADD CONSTRAINT [PK_result] primary key (ID)

GO

ALTER TABLE cyreport ADD [id] [int] IDENTITY(1,1) NOT NULL

GO

ALTER TABLE cyreport ADD CONSTRAINT [PK_cyreport] primary key (ID)

GO

ALTER TABLE PATIENT ADD [master] [int] NULL

GO
