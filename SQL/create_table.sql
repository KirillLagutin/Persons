CREATE TABLE tab_persons (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    age INT NOT NULL,
    is_delete BOOL NOT NULL DEFAULT FALSE
);

INSERT INTO host1323541_persons.tab_persons (first_name, last_name, age, is_delete)
VALUES ('Andrey', 'Starinin', 35, DEFAULT);