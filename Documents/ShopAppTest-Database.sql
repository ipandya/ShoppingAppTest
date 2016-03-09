CREATE DATABASE ShoppingAppTest

CREATE TABLE CustomerMaster(
	CustomerID numeric(18, 0) IDENTITY(1,1) NOT NULL,
	CustomerTitle bit NOT NULL,
	CustomerFName text NOT NULL,
	CustomerLName nchar(10) NOT NULL,
	[Address] text NULL,
	ZipCode text NULL,
	City text NOT NULL,
	EmailAddress text NOT NULL,
 CONSTRAINT PK_CustomerMaster PRIMARY KEY CLUSTERED 
(
	CustomerID ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
