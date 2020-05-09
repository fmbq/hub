CREATE TABLE ApiToken (
    `id` TEXT NOT NULL PRIMARY KEY,
    `token` TEXT NOT NULL UNIQUE,
    `name` TEXT NOT NULL,
    `deleted` TEXT
);

CREATE TABLE Person (
    `id` TEXT NOT NULL PRIMARY KEY,
    `name` TEXT NOT NULL,
    `birthday` TEXT
);

CREATE TABLE Quiz (
    `id` TEXT NOT NULL PRIMARY KEY,
    `roundId` TEXT NOT NULL REFERENCES Round(`id`),
    `room` TEXT NOT NULL,
    `passcode` TEXT NOT NULL
);

CREATE TABLE Round (
    `id` TEXT NOT NULL PRIMARY KEY,
    `tournamentId` TEXT NOT NULL REFERENCES Tournament(`id`),
    `type` TEXT NOT NULL CHECK (`type` IN ("team", "individuals")),
    `division` TEXT,
    `startDate` TEXT,
    `freeform` INTEGER NOT NULL CHECK (`freeform` IN (0, 1))
);

-- Assignments of quizzers to quizzes for a particular round.
CREATE TABLE IndividualRoundAssignment (
    `roundId` TEXT NOT NULL REFERENCES Round(`id`),
    `personId` TEXT NOT NULL REFERENCES Person(`id`),
    `quizId` TEXT NOT NULL REFERENCES Quiz(`id`),

    -- A quizzer can only be assigned once per round.
    PRIMARY KEY (`roundId`, `personId`)
);

-- Assignments of teams to quizzes for a particular round.
CREATE TABLE TeamRoundAssignment (
    `roundId` TEXT NOT NULL REFERENCES Round(`id`),
    `teamId` TEXT NOT NULL REFERENCES Team(`id`),
    `quizId` TEXT NOT NULL REFERENCES Quiz(`id`),

    -- A team can only be assigned once per round.
    PRIMARY KEY (`roundId`, `teamId`)
);

CREATE TABLE ScoringSession (
    `id` TEXT NOT NULL PRIMARY KEY,
    `quizId` TEXT NOT NULL REFERENCES Quiz(`id`),
    `expirationDate` TEXT
);

CREATE TABLE Team (
    `id` TEXT NOT NULL PRIMARY KEY,
    `tournamentId` TEXT NOT NULL REFERENCES Tournament(`id`),
    `name` TEXT NOT NULL,
    `quizzers` JSON DEFAULT "[]"
);

CREATE TABLE Tournament (
    `id` TEXT NOT NULL PRIMARY KEY,
    `season` INTEGER NOT NULL,
    `title` TEXT NOT NULL,
    `description` TEXT,
    `location` TEXT,
    `startDate` TEXT NOT NULL,
    `endDate` TEXT NOT NULL
);

CREATE TABLE User (
    `id` TEXT NOT NULL PRIMARY KEY,
    `email` TEXT NOT NULL,
    `password` TEXT
);

PRAGMA user_version = 1;
