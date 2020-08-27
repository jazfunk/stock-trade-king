CREATE TABLE "users" (
  "id" SERIAL PRIMARY KEY,
  "first_name" varchar NOT NULL,
  "last_name" varchar NOT NULL,
  "email" varchar NOT NULL,
  "password" varchar NOT NULL
);

CREATE TABLE "holdings" (
  "id" SERIAL PRIMARY KEY,
  "user_id" int NOT NULL,
  "stock_symbol" varchar NOT NULL,
  "company_name" varchar NOT NULL,
  "purchase_date" timestamp NOT NULL,
  "purchase_price" float NOT NULL,
  "purchase_qty" int NOT NULL,
  "latest_price" float,
  "week52_high" float,
  "week52_low" float,
  "ytd_change" float,
  "created_at" timestamp DEFAULT 'now()'
);

CREATE TABLE "ledger" (
  "id" SERIAL PRIMARY KEY,
  "holding_id" int NOT NULL,
  "ledger_type" varchar,
  "ledger_date" timestamp,
  "ledger_price" float NOT NULL,
  "ledger_qty" int NOT NULL,
  "created_at" timestamp DEFAULT 'now()'
);

ALTER TABLE "holdings" ADD FOREIGN KEY ("user_id") REFERENCES "users" ("id");

ALTER TABLE "ledger" ADD FOREIGN KEY ("holding_id") REFERENCES "holdings" ("id");
