USE Master

IF EXISTS(SELECT 1 FROM sys.databases WHERE name='MealPlanner')
BEGIN
	ALTER DATABASE MealPlanner SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE MealPlanner
END
GO

CREATE DATABASE MealPlanner
GO

USE MealPlanner
GO

CREATE TABLE Recipes (
	RecipeId INT IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(500),
	Rating INT,
	[Description] NVARCHAR(MAX),
	Directions NVARCHAR(MAX),
	ImageUrl NVARCHAR(500),
	PRIMARY KEY (RecipeId)
)

CREATE TABLE IngredientCategories (
	IngredientCategoryId INT IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(500),
	PRIMARY KEY (IngredientCategoryId)
)

CREATE TABLE Ingredients (
	IngredientId INT IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(500),
	IngredientCategoryId INT NOT NULL
	PRIMARY KEY (IngredientId),
	FOREIGN KEY (IngredientCategoryId) REFERENCES IngredientCategories(IngredientCategoryId)
)

CREATE TABLE MeasureUnits (
	MeasureUnitId INT IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(500),
	PRIMARY KEY (MeasureUnitId)
)

CREATE TABLE RecipeIngredients (
	RecipeIngredientId INT IDENTITY(1,1) NOT NULL,
	RecipeId INT NOT NULL,
	IngredientId INT NOT NULL,
	MeasureUnitId INT NOT NULL,
	Quantity INT NOT NULL,
	PRIMARY KEY (RecipeIngredientId),
	FOREIGN KEY (RecipeId) REFERENCES Recipes(RecipeId),
	FOREIGN KEY (IngredientId) REFERENCES Ingredients(IngredientId),
	FOREIGN KEY (MeasureUnitId ) REFERENCES MeasureUnits(MeasureUnitId )

)

CREATE TABLE Tags (
	TagId INT IDENTITY(1,1) NOT NULL,
	Value NVARCHAR(500) NOT NULL,
	PRIMARY KEY (TagId)
)

CREATE TABLE RecipeTags (
	RecipeTagId INT IDENTITY(1,1) NOT NULL,
	RecipeId INT NOT NULL,
	TagId INT NOT NULL,
	PRIMARY KEY (RecipeTagId),
	FOREIGN KEY (RecipeId) REFERENCES Recipes(RecipeId),
	FOREIGN KEY (TagId) REFERENCES Tags(TagId),
)

