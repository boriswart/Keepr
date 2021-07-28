CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS keeps(
  id INT NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'Keep Name',
  description varchar(255) COMMENT 'Keeps description',
  img varchar(255) COMMENT 'keeps image',
  views INT COMMENT 'number of clicks to view',
  shares INT COMMENT 'number of shared',
  keeps INT COMMENT 'number of inclusion into vault',
  creatorId varchar(255) COMMENT 'FK: creator user account',
  FOREIGN KEY (creatorId) REFERENCES Accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
DROP TABLE keeps;
select
  *
from
  Accounts;
INSERT INTO
  keeps(name, description, img, creatorId)
VALUES
  (
    "Grizzly 3",
    "Bears just want to have fun. Thats all they really want.Is ",
    "https://as2.ftcdn.net/v2/jpg/02/10/81/97/500_F_210819777_7lNUUycYe003Q2NN91FH4oUYNE6pWfpT.jpg",
    "60cb8ac8f08aa1ea8ecb824a"
  );
SELECT
  k.name,
  k.description,
  k.img,
  k.creatorId,
  a.*
FROM
  keeps k
  JOIN Accounts a ON k.creatorId = a.id;
SELECT
  k.description,
  k.img,
  a.*
FROM
  keeps k
  JOIN Accounts a ON k.creatorId = a.id
WHERE
  k.id = 2;
select
  *
from
  keeps