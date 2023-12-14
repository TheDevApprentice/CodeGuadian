CREATE DATABASE IF NOT EXISTS myDatabase;
USE myDatabase;

CREATE TABLE IF NOT EXISTS SecurityConfiguration (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    value VARCHAR(255) NOT NULL
);

INSERT INTO SecurityConfiguration (name, value) VALUES ('secretKey', 'your128BitSecretKey');
