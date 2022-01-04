
use LibraryManagementSystem;
CREATE TABLE book (
  id INT,
  title VARCHAR(500),
  category VARCHAR(500),
  publication_date DATE,
  copies_owned INT,
  CONSTRAINT pk_book PRIMARY KEY (id),
);

CREATE TABLE author (
  id INT,
  name VARCHAR(300),
  CONSTRAINT pk_author PRIMARY KEY (id)
);

CREATE TABLE member (
  id INT,
  name VARCHAR(300),
  contact_number varchar(300),
  CONSTRAINT pk_member PRIMARY KEY (id),
);

CREATE TABLE book_author (
  id INT,
  book_id INT,
  author_id INT,
  CONSTRAINT pk_book_author PRIMARY KEY (id),
  CONSTRAINT fk_bookauthor_book FOREIGN KEY (book_id) REFERENCES book(id),
  CONSTRAINT fk_bookauthor_author FOREIGN KEY (author_id) REFERENCES author(id)
);

CREATE TABLE borrow (
  id INT,
  book_id INT,
  member_id INT,
  borrow_date DATE,
  returned_date DATE,
  CONSTRAINT pk_borrow PRIMARY KEY (id),
  CONSTRAINT fk_borrow_book FOREIGN KEY (book_id) REFERENCES book(id),
  CONSTRAINT fk_borrow_member FOREIGN KEY (member_id) REFERENCES member(id)
);


--create TRIGGER checkthedateofbook
--ON book
--AFTER INSERT
--AS
--BEGIN

--declare  @idd date
--set @idd = (select publication_date from inserted ) 
--if @idd > GETDATE()     UPDATE book SET publication_date = GETDATE();
--END




--create TRIGGER checknegativeid
--ON borrow
--AFTER INSERT
--AS
--BEGIN

--declare  @idd integer
--set @idd = (select id from inserted ) 
--if @idd < 0 
--     UPDATE borrow SET id = id*-1;
--END



--create TRIGGER checkthedateofborrow
--ON borrow
--AFTER INSERT
--AS
--BEGIN

--declare  @idd date
--set @idd = (select borrow_date from inserted ) 
--if @idd > GETDATE()     UPDATE borrow SET borrow_date = GETDATE();
--END


--create TRIGGER checkthedateofreturn
--ON borrow
--AFTER INSERT
--AS
--BEGIN

--declare  @idd date
--set @idd = (select returned_date from inserted ) 
--if @idd > GETDATE()     UPDATE borrow SET returned_date = GETDATE();
--END










