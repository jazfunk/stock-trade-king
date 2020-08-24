CREATE TYPE "ledger_types" AS ENUM (
  'BUY',
  'SELL'
);

CREATE TABLE "users" (
  "id" SERIAL PRIMARY KEY,
  "first_name" varchar NOT NULL,
  "last_name" varchar NOT NULL,
  "email" varchar NOT NULL,
  "password" varchar NOT NULL
);

CREATE TABLE "holdings" (
  "id" SERIAL PRIMARY KEY,
  "users_id" int NOT NULL,
  "stock_symbol" varchar NOT NULL,
  "company_name" varchar NOT NULL,
  "purchase_date" datetime NOT NULL,
  "purchase_price" float NOT NULL,
  "purchase_qty" int NOT NULL,
  "latest_price" float,
  "week52_high" float,
  "week52_low" float,
  "ytd_change" float,
  "created_at" datetime DEFAULT 'now()'
);

CREATE TABLE "ledger" (
  "id" SERIAL PRIMARY KEY,
  "holdings_id" int NOT NULL,
  "ledger_type" ledger_types,
  "ledger_date" datetime,
  "ledger_price" float NOT NULL,
  "ledger_qty" int NOT NULL,
  "created_at" datetime DEFAULT 'now()'
);

ALTER TABLE "holdings" ADD FOREIGN KEY ("users_id") REFERENCES "users" ("id");

ALTER TABLE "ledger" ADD FOREIGN KEY ("holdings_id") REFERENCES "holdings" ("id");
