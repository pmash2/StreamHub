CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "GlobalConfigs" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_GlobalConfigs" PRIMARY KEY AUTOINCREMENT,
    "Key" TEXT NULL,
    "Description" TEXT NULL,
    "Value" TEXT NULL,
    "DateUpdated" TEXT NOT NULL
);

CREATE TABLE "StaticCommands" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_StaticCommands" PRIMARY KEY AUTOINCREMENT,
    "Keyword" TEXT NULL,
    "Text" TEXT NULL
);

CREATE TABLE "TodaysMessage" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_TodaysMessage" PRIMARY KEY AUTOINCREMENT,
    "Message" TEXT NULL,
    "Date" TEXT NOT NULL
);

CREATE TABLE "TransactionLog" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_TransactionLog" PRIMARY KEY AUTOINCREMENT,
    "Points" INTEGER NOT NULL,
    "Receiver" TEXT NULL,
    "Giver" TEXT NULL,
    "Date" TEXT NOT NULL,
    "Notes" TEXT NULL
);

CREATE TABLE "UserPoints" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_UserPoints" PRIMARY KEY AUTOINCREMENT,
    "Viewer" TEXT NULL,
    "Points" INTEGER NOT NULL
);

CREATE TABLE "Users" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "EntryDate" TEXT NOT NULL
);

CREATE TABLE "WinLoss" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_WinLoss" PRIMARY KEY AUTOINCREMENT,
    "UserName" TEXT NULL,
    "DidWin" INTEGER NOT NULL,
    "Date" TEXT NOT NULL,
    "Game" TEXT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210304005945_InitialCreate', '5.0.3');

COMMIT;


