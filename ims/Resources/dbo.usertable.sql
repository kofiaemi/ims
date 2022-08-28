CREATE TABLE [dbo].[usertable] (
    [UFirstname]   VARCHAR (50) NOT NULL,
    [ULastname]    VARCHAR (50) NOT NULL,
    [UOthername]   VARCHAR (50) NULL,
    [UEmail]       VARCHAR (50) NOT NULL,
    [UPhonenumber] VARCHAR (50) NOT NULL,
    [UUsername]    VARCHAR (50) NOT NULL,
    [UPassword]    VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_usertable] PRIMARY KEY CLUSTERED ([UUsername])
);

