
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/10/2018 10:52:30
-- Generated from EDMX file: C:\Users\Roman\Documents\GitHub\FooDoAppp\FooDo2\Models\FooDoModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QFoodDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_OrderFood_food]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[orderFood] DROP CONSTRAINT [FK_OrderFood_food];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderFood_orders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[orderFood] DROP CONSTRAINT [FK_OrderFood_orders];
GO
IF OBJECT_ID(N'[dbo].[FK_orders_tables]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[orders] DROP CONSTRAINT [FK_orders_tables];
GO
IF OBJECT_ID(N'[dbo].[FK_orders_users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[orders] DROP CONSTRAINT [FK_orders_users];
GO
IF OBJECT_ID(N'[dbo].[FK_orders_users1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[orders] DROP CONSTRAINT [FK_orders_users1];
GO
IF OBJECT_ID(N'[dbo].[FK_tables_tables]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tables] DROP CONSTRAINT [FK_tables_tables];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[food]', 'U') IS NOT NULL
    DROP TABLE [dbo].[food];
GO
IF OBJECT_ID(N'[dbo].[orderFood]', 'U') IS NOT NULL
    DROP TABLE [dbo].[orderFood];
GO
IF OBJECT_ID(N'[dbo].[orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[orders];
GO
IF OBJECT_ID(N'[dbo].[tables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tables];
GO
IF OBJECT_ID(N'[dbo].[users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'foods'
CREATE TABLE [dbo].[foods] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nchar(10)  NOT NULL,
    [details] nchar(10)  NOT NULL,
    [img] varbinary(max)  NULL,
    [price] float  NULL
);
GO

-- Creating table 'orderFoods'
CREATE TABLE [dbo].[orderFoods] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [idOrder] int  NOT NULL,
    [idFood] int  NOT NULL
);
GO

-- Creating table 'orders'
CREATE TABLE [dbo].[orders] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [idTable] int  NOT NULL,
    [idUserOpen] int  NOT NULL,
    [idUserClose] int  NULL,
    [timeOpen] datetime  NOT NULL,
    [timeClose] datetime  NULL,
    [details] varchar(50)  NULL,
    [totalPrice] float  NULL
);
GO

-- Creating table 'tables'
CREATE TABLE [dbo].[tables] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [positionX] int  NOT NULL,
    [positionY] int  NOT NULL,
    [number] int  NOT NULL,
    [size] int  NOT NULL
);
GO

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nchar(10)  NULL,
    [surname] nchar(10)  NULL,
    [login] nchar(10)  NULL,
    [password] nchar(10)  NULL,
    [manager] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'foods'
ALTER TABLE [dbo].[foods]
ADD CONSTRAINT [PK_foods]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'orderFoods'
ALTER TABLE [dbo].[orderFoods]
ADD CONSTRAINT [PK_orderFoods]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'orders'
ALTER TABLE [dbo].[orders]
ADD CONSTRAINT [PK_orders]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tables'
ALTER TABLE [dbo].[tables]
ADD CONSTRAINT [PK_tables]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idFood] in table 'orderFoods'
ALTER TABLE [dbo].[orderFoods]
ADD CONSTRAINT [FK_OrderFood_food]
    FOREIGN KEY ([idFood])
    REFERENCES [dbo].[foods]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderFood_food'
CREATE INDEX [IX_FK_OrderFood_food]
ON [dbo].[orderFoods]
    ([idFood]);
GO

-- Creating foreign key on [idOrder] in table 'orderFoods'
ALTER TABLE [dbo].[orderFoods]
ADD CONSTRAINT [FK_OrderFood_orders]
    FOREIGN KEY ([idOrder])
    REFERENCES [dbo].[orders]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderFood_orders'
CREATE INDEX [IX_FK_OrderFood_orders]
ON [dbo].[orderFoods]
    ([idOrder]);
GO

-- Creating foreign key on [idUserOpen] in table 'orders'
ALTER TABLE [dbo].[orders]
ADD CONSTRAINT [FK_orders_users]
    FOREIGN KEY ([idUserOpen])
    REFERENCES [dbo].[users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_orders_users'
CREATE INDEX [IX_FK_orders_users]
ON [dbo].[orders]
    ([idUserOpen]);
GO

-- Creating foreign key on [idUserClose] in table 'orders'
ALTER TABLE [dbo].[orders]
ADD CONSTRAINT [FK_orders_users1]
    FOREIGN KEY ([idUserClose])
    REFERENCES [dbo].[users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_orders_users1'
CREATE INDEX [IX_FK_orders_users1]
ON [dbo].[orders]
    ([idUserClose]);
GO

-- Creating foreign key on [idTable] in table 'orders'
ALTER TABLE [dbo].[orders]
ADD CONSTRAINT [FK_orders_tables]
    FOREIGN KEY ([idTable])
    REFERENCES [dbo].[tables]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_orders_tables'
CREATE INDEX [IX_FK_orders_tables]
ON [dbo].[orders]
    ([idTable]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------