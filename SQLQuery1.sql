
CREATE DATABASE FundSystemDb;

CREATE TABLE [dbo].[AddressBook] (
    [Address_Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Street]       NVARCHAR (100) NULL,
    [Postal_Code]  NVARCHAR (50)  NULL,
    [City]         NVARCHAR (100) NULL,
    [Country_Code] NVARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([Address_Id] ASC)
);
CREATE TABLE [dbo].[Clients] (
    [Client_Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Ssn_No]      NVARCHAR (50) NULL,
    [First_Name]  NVARCHAR (50) NULL,
    [Middle_Name] NVARCHAR (50) NULL,
    [Last_Name]   NVARCHAR (50) NULL,
    [Gender]      CHAR (10)     NULL,
    [Address_Id]  INT           NULL,
    [Email]       NVARCHAR (50) NULL,
    [Birth_Date]  DATE          NULL,
    [M-Date]      DATE          NULL,
    PRIMARY KEY CLUSTERED ([Client_Id] ASC),
    FOREIGN KEY ([Address_Id]) REFERENCES [dbo].[AddressBook] ([Address_Id])
);
CREATE TABLE [dbo].[Company] (
    [Company_Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Company_Code] NVARCHAR (50)  NULL,
    [Company_Name] NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Company_Id] ASC)
);

CREATE TABLE [dbo].[Fund_Orders] (
    [Fund_Order_Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Order_No_Units]    NVARCHAR (50) NULL,
    [Fund_Id]           INT           NULL,
    [Fund_Price]        FLOAT (53)    NULL,
    [Date_Order]        NCHAR (10)    NULL,
    [Order_Amount]      FLOAT (53)    NULL,
    [Type_Order]        NVARCHAR (10) NULL,
    [Fund_Order_No]     INT           NULL,
    [Fund_Order_Status] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([FundOrder_Id] ASC)
);
CREATE TABLE [dbo].[Funds] (
    [Fund_Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Fund_No]    NVARCHAR (50) NULL,
    [Fee]       FLOAT (53)    NULL,
    [Company_Id] INT           NULL,
    [Rating]    FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([Fund_Id] ASC),
    FOREIGN KEY ([Company_Id]) REFERENCES [dbo].[Company] ([Company_Id])
);

CREATE TABLE [dbo].[Holdings] (
    [Holding_Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Company_Id]   INT           NULL,
    [InsuranceId]  INT           NULL,
    [FundID]       INT           NULL,
    [No_Of_Units]  NVARCHAR (50) NULL,
    [Date_Holding] DATE          NULL,
    [Fund_Price]   FLOAT (53)    NULL,
    [Insurance_No]  NVARCHAR (50) NULL,
    [End_Date]     DATE          NULL,
    PRIMARY KEY CLUSTERED ([HoldingID] ASC),
    FOREIGN KEY ([Company_Id]) REFERENCES [dbo].[Company] ([Company_Id]),
    FOREIGN KEY ([Insurance_Id]) REFERENCES [dbo].[Insurance] ([Insurance_Id]),
    FOREIGN KEY ([Fund_Id]) REFERENCES [dbo].[Funds] ([Fund_Id])
);

CREATE TABLE [dbo].[INS-Status] (
    [Status_Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Status_Name] NVARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([StatusId] ASC)
);

CREATE TABLE [dbo].[Insurance] (
    [Insurance_Id] INT           IDENTITY (1, 1) NOT NULL,
    [Insurance_No] NVARCHAR (50) NULL,
    [Nominee]     NCHAR (10)    NULL,
    [Start_Date]   DATE          NULL,
    [Z-date]      DATE          NULL,
    [Z-endDate]   DATE          NULL,
    [Client_Id]   INT           NULL,
    [Product_Id]   INT           NULL,
    [Status_Id]    INT           NULL,
    [End_Date]    DATE          NULL,
    PRIMARY KEY CLUSTERED ([Insurance_Id] ASC),
    FOREIGN KEY ([Client_Id]) REFERENCES [dbo].[Clients] ([Client_Id]),
    FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Products] ([Product_Id]),
    FOREIGN KEY ([Status_Id]) REFERENCES [dbo].[INS-Status] ([Status_Id])
);
CREATE TABLE [dbo].[Inv-Profile] (
    [Inv-Profile_Id] INT           IDENTITY (1, 1) NOT NULL,
    [Company_Id]    INT           NULL,
    [Insurance_No]   NVARCHAR (50) NULL,
    [Percent]       FLOAT (53)    NULL,
    [Fund_Id]        INT           NULL,
    [Start_Date]    DATE          NULL,
    [End_Date]      DATE          NULL,
    [Insurance_Id]   INT           NULL,
    PRIMARY KEY CLUSTERED ([Inv-Profile_Id] ASC),
    FOREIGN KEY ([Company_Id]) REFERENCES [dbo].[Company] ([Company_Id]),
    FOREIGN KEY ([Insurance_Id]) REFERENCES [dbo].[Insurance] ([Insurance_Id]),
    FOREIGN KEY ([Fund_Id]) REFERENCES [dbo].[Funds] ([Fund_Id])
);
CREATE TABLE [dbo].[Prices] (
    [Price_Id]    INT        IDENTITY (1, 1) NOT NULL,
    [Fund_Id]     INT        NULL,
    [Company_Id] INT        NULL,
    [Find_price] FLOAT (53) NULL,
    [Date_price] FLOAT (53) NULL,
    PRIMARY KEY CLUSTERED ([Price_Id] ASC),
    FOREIGN KEY ([Fund_Id]) REFERENCES [dbo].[Funds] ([Fund_Id]),
    FOREIGN KEY ([Company_Id]) REFERENCES [dbo].[Company] ([Company_Id])
);

CREATE TABLE [dbo].[Product_Rules] (
    [Product_Rules_Id] INT            NOT NULL,
    [Product_Name]    NVARCHAR (50)  NULL,
    [Nominee]         NCHAR (10)     NULL,
    [Z-age]           INT            NULL,
    [Claim_Period]    NVARCHAR (200) NULL,
    [Move_Ability]    NVARCHAR (200) NULL,
    [End_Date]        DATE           NULL,
    PRIMARY KEY CLUSTERED ([Product_Rules_Id] ASC)
);
CREATE TABLE [dbo].[Products] (
    [Product_Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Product_Name] NVARCHAR (100) NULL,
    [Product_Fee] FLOAT (53)     NULL,
    [Tax_Fee]     FLOAT (53)     NULL,
    PRIMARY KEY CLUSTERED ([Product_Id] ASC)
);
CREATE TABLE [dbo].[Task] (
    [Task_Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Company_Id]      INT           NULL,
    [Task_Start_Id]  NVARCHAR (50) NULL,
    [Task_No]        NVARCHAR (50) NULL,
    [Task_Date]      DATE          NULL,
    [Task_Amount]    FLOAT (53)    NULL,
    [Task_Fee]       FLOAT (53)    NULL,
    [Task_Status]    NVARCHAR (50) NULL,
    [Task_End_Date]  DATE          NULL,
    [Task_Order_num] NVARCHAR (50) NULL,
    [Task_Order_Id]    INT           NULL,
    PRIMARY KEY CLUSTERED ([Task_Id] ASC),
    FOREIGN KEY ([Company_Id]) REFERENCES [dbo].[Company] ([Company_Id])
);
CREATE TABLE [dbo].[Task_Orders] (
    [Task_Order_Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Task_Order_No]    NVARCHAR (50)  NULL,
    [Description]     NVARCHAR (200) NULL,
    [Task-On-GoingId] INT            NULL,
    PRIMARY KEY CLUSTERED ([Task_Order_Id] ASC),
    FOREIGN KEY ([Task-On-Going_Id]) REFERENCES [dbo].[Task-On-Going] ([Task-On-Going_Id])
);

CREATE TABLE [dbo].[Task_On_Going] (
    [Task_On_Going_Id] INT           IDENTITY (1, 1) NOT NULL,
    [Company_Id]      INT           NULL,
    [Insurance_No]     NVARCHAR (50) NULL,
    [Task_No]         NVARCHAR (50) NULL,
    [Fund_Id]          INT           NULL,
    [Task_Start_Date] DATE          NULL,
    [Task_End_Date]   DATE          NULL,
    [Type_of_Task]    NVARCHAR (50) NULL,
    [Task_Amount]     FLOAT (53)    NULL,
    [TaskNo_of_Units] NVARCHAR (50) NULL,
    [Fund_Price]      FLOAT (53)    NULL,
    [Insurance_Id]     INT           NULL,
    [TaskOrderId]     INT           NULL,
    PRIMARY KEY CLUSTERED ([Task_On_Going_Id] ASC),
    FOREIGN KEY ([TaskOrder_Id]) REFERENCES [dbo].[Task_Orders] ([TaskOrder_Id]),
    FOREIGN KEY ([Company_Id]) REFERENCES [dbo].[Company] ([Company_Id]),
    FOREIGN KEY ([Insurance_Id]) REFERENCES [dbo].[Insurance] ([Insurance_Id])
);







CREATE TABLE [dbo].[Task_Orders] (
    [Task_Order_Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Task_Order_No]    NVARCHAR (50)  NULL,
    [Description]     NVARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([Task_Order_Id] ASC)
);

CREATE TABLE [dbo].[Task-On-Going] (
    [Task-On-Going_Id] INT           IDENTITY (1, 1) NOT NULL,
    [Company_Id]      INT           NULL,
    [Insurance_No]     NVARCHAR (50) NULL,
    [Task_No]         NVARCHAR (50) NULL,
    [Fund_Id]          INT           NULL,
    [Task_Start_Date] DATE          NULL,
    [Task_End_Date]   DATE          NULL,
    [Type_of_Task]    NVARCHAR (50) NULL,
    [Task_Amount]     FLOAT (53)    NULL,
    [TaskNo_of_Units] NVARCHAR (50) NULL,
    [Fund_Price]      FLOAT (53)    NULL,
    [Insurance_Id]     INT           NULL,
    [Task_Order_Id]     INT           NULL,
    PRIMARY KEY CLUSTERED ([Task-On-Going_Id] ASC),
    FOREIGN KEY ([Task_Order_Id]) REFERENCES [dbo].[Task_Orders] ([Task_Order_Id]),
    FOREIGN KEY ([Company_Id]) REFERENCES [dbo].[Company] ([Company_Id]),
    FOREIGN KEY ([Insurance_Id]) REFERENCES [dbo].[Insurance] ([Insurance_Id])
);






