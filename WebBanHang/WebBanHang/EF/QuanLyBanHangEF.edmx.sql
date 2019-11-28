
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/28/2019 17:46:48
-- Generated from EDMX file: D:\SourceCode\Github\WebBanHang_ASP.Net\WebBanHang\WebBanHang\EF\QuanLyBanHangEF.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QuanLyBanHang];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_order_details__orders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[order_details] DROP CONSTRAINT [fk_order_details__orders];
GO
IF OBJECT_ID(N'[dbo].[fk_order_details__products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[order_details] DROP CONSTRAINT [fk_order_details__products];
GO
IF OBJECT_ID(N'[dbo].[fk_orders__customers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[orders] DROP CONSTRAINT [fk_orders__customers];
GO
IF OBJECT_ID(N'[dbo].[fk_orders__employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[orders] DROP CONSTRAINT [fk_orders__employees];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[configs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[configs];
GO
IF OBJECT_ID(N'[dbo].[customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[customers];
GO
IF OBJECT_ID(N'[dbo].[employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[employees];
GO
IF OBJECT_ID(N'[dbo].[order_details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[order_details];
GO
IF OBJECT_ID(N'[dbo].[orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[orders];
GO
IF OBJECT_ID(N'[dbo].[products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[products];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'configs'
CREATE TABLE [dbo].[configs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [key] varchar(255)  NOT NULL,
    [value] nvarchar(1000)  NOT NULL
);
GO

-- Creating table 'customers'
CREATE TABLE [dbo].[customers] (
    [id] int IDENTITY(1,1) NOT NULL,
    [last_name] nvarchar(50)  NULL,
    [first_name] nvarchar(50)  NULL,
    [email] nvarchar(50)  NULL,
    [company] nvarchar(50)  NULL,
    [phone] nvarchar(25)  NULL,
    [address1] nvarchar(150)  NULL,
    [address2] nvarchar(150)  NULL,
    [city] nvarchar(50)  NULL,
    [state] nvarchar(50)  NULL,
    [postal_code] nvarchar(15)  NULL,
    [country] nvarchar(50)  NULL
);
GO

-- Creating table 'employees'
CREATE TABLE [dbo].[employees] (
    [id] int IDENTITY(1,1) NOT NULL,
    [last_name] nvarchar(50)  NULL,
    [first_name] nvarchar(50)  NULL,
    [email] nvarchar(50)  NULL,
    [password] nvarchar(500)  NULL,
    [avatar] nvarchar(250)  NULL,
    [job_title] nvarchar(50)  NULL,
    [department] nvarchar(50)  NULL,
    [manager_id] int  NULL,
    [phone] nvarchar(25)  NULL,
    [address1] nvarchar(150)  NULL,
    [address2] nvarchar(150)  NULL,
    [city] nvarchar(50)  NULL,
    [state] nvarchar(50)  NULL,
    [postal_code] nvarchar(15)  NULL,
    [country] nvarchar(50)  NULL
);
GO

-- Creating table 'order_details'
CREATE TABLE [dbo].[order_details] (
    [order_id] int IDENTITY(1,1) NOT NULL,
    [product_id] int  NOT NULL,
    [quantity] decimal(18,4)  NOT NULL,
    [unit_price] decimal(19,4)  NULL,
    [discount] decimal(18,0)  NOT NULL,
    [order_detail_status] nvarchar(25)  NULL,
    [date_allocated] datetime  NULL
);
GO

-- Creating table 'orders'
CREATE TABLE [dbo].[orders] (
    [id] int IDENTITY(1,1) NOT NULL,
    [employee_id] int  NULL,
    [customer_id] int  NULL,
    [order_date] datetime  NULL,
    [shipped_date] datetime  NULL,
    [ship_name] nvarchar(50)  NULL,
    [ship_address1] nvarchar(150)  NULL,
    [ship_address2] nvarchar(150)  NULL,
    [ship_city] nvarchar(50)  NULL,
    [ship_state] nvarchar(50)  NULL,
    [ship_postal_code] nvarchar(50)  NULL,
    [ship_country] nvarchar(50)  NULL,
    [shipping_fee] decimal(19,4)  NULL,
    [payment_type] nvarchar(50)  NULL,
    [paid_date] datetime  NULL,
    [order_status] nvarchar(25)  NULL
);
GO

-- Creating table 'products'
CREATE TABLE [dbo].[products] (
    [id] int IDENTITY(1,1) NOT NULL,
    [product_code] nvarchar(25)  NULL,
    [product_name] nvarchar(50)  NULL,
    [description] nvarchar(250)  NULL,
    [standard_cost] decimal(19,4)  NULL,
    [list_price] decimal(19,4)  NOT NULL,
    [target_level] int  NULL,
    [reorder_level] int  NULL,
    [minimum_reorder_quantity] int  NULL,
    [quantity_per_unit] nvarchar(50)  NULL,
    [discontinued] tinyint  NOT NULL,
    [category] nvarchar(50)  NULL,
    [image] varchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'configs'
ALTER TABLE [dbo].[configs]
ADD CONSTRAINT [PK_configs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'customers'
ALTER TABLE [dbo].[customers]
ADD CONSTRAINT [PK_customers]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'employees'
ALTER TABLE [dbo].[employees]
ADD CONSTRAINT [PK_employees]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [order_id], [product_id] in table 'order_details'
ALTER TABLE [dbo].[order_details]
ADD CONSTRAINT [PK_order_details]
    PRIMARY KEY CLUSTERED ([order_id], [product_id] ASC);
GO

-- Creating primary key on [id] in table 'orders'
ALTER TABLE [dbo].[orders]
ADD CONSTRAINT [PK_orders]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [PK_products]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [customer_id] in table 'orders'
ALTER TABLE [dbo].[orders]
ADD CONSTRAINT [fk_orders__customers]
    FOREIGN KEY ([customer_id])
    REFERENCES [dbo].[customers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_orders__customers'
CREATE INDEX [IX_fk_orders__customers]
ON [dbo].[orders]
    ([customer_id]);
GO

-- Creating foreign key on [employee_id] in table 'orders'
ALTER TABLE [dbo].[orders]
ADD CONSTRAINT [fk_orders__employees]
    FOREIGN KEY ([employee_id])
    REFERENCES [dbo].[employees]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_orders__employees'
CREATE INDEX [IX_fk_orders__employees]
ON [dbo].[orders]
    ([employee_id]);
GO

-- Creating foreign key on [order_id] in table 'order_details'
ALTER TABLE [dbo].[order_details]
ADD CONSTRAINT [fk_order_details__orders]
    FOREIGN KEY ([order_id])
    REFERENCES [dbo].[orders]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [product_id] in table 'order_details'
ALTER TABLE [dbo].[order_details]
ADD CONSTRAINT [fk_order_details__products]
    FOREIGN KEY ([product_id])
    REFERENCES [dbo].[products]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_order_details__products'
CREATE INDEX [IX_fk_order_details__products]
ON [dbo].[order_details]
    ([product_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------