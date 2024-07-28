\c postgres;
drop database notes;
CREATE DATABASE notes;
\c notes;

CREATE SEQUENCE admin_seq; 
CREATE TABLE admin (
    id VARCHAR PRIMARY KEY DEFAULT CONCAT('ADM', LPAD(nextval('admin_seq')::TEXT, 3, '0')),
    nom VARCHAR NOT NULL,
    password VARCHAR NOT NULL
);

CREATE SEQUENCE promotion_seq; 
CREATE TABLE promotion (
    id VARCHAR PRIMARY KEY DEFAULT CONCAT('PROM', LPAD(nextval('promotion_seq')::TEXT, 3, '0')),
    nom VARCHAR NOT NULL
);

CREATE SEQUENCE etudiant_seq;
CREATE TABLE etudiant (
    id VARCHAR PRIMARY KEY DEFAULT CONCAT('ET', LPAD(nextval('etudiant_seq')::TEXT, 6, '0')),
    id_promotion VARCHAR NOT NULL REFERENCES promotion(id),
    num_etu VARCHAR NOT NULL,
    nom VARCHAR NOT NULL,
    prenom VARCHAR NOT NULL,
    date_de_naissance DATE
);

CREATE SEQUENCE semestre_seq;
CREATE TABLE semestre (
    id VARCHAR PRIMARY KEY DEFAULT CONCAT('SMTR', LPAD(nextval('semestre_seq')::TEXT, 3, '0')),
    nom VARCHAR NOT NULL
);

CREATE SEQUENCE matiere_seq;
CREATE TABLE matiere (
    id VARCHAR PRIMARY KEY DEFAULT CONCAT('MT', LPAD(nextval('matiere_seq')::TEXT, 3, '0')),
    id_semestre VARCHAR NOT NULL REFERENCES semestre(id),
    nom VARCHAR NOT NULL,
    code VARCHAR NOT NULL,
    credit INT,
    optionnelle VARCHAR
);

CREATE SEQUENCE note_seq;
CREATE TABLE note (
    id VARCHAR PRIMARY KEY DEFAULT CONCAT('NT', LPAD(nextval('note_seq')::TEXT, 3, '0')),
    id_etudiant VARCHAR NOT NULL REFERENCES etudiant(id),
    id_matiere VARCHAR NOT NULL REFERENCES matiere(id),
    note DOUBLE PRECISION
);

select 
    note.id,
    note.id_etudiant ,
    note.id_matiere ,
    note.note ,
    e.id_promotion ,
    m.id_semestre ,
    m.nom as nom_matiere,
    m.code as code_matiere,
    m.credit,
    m.optionnelle
from note
    join etudiant as e on note.id_etudiant = e.id
    join matiere as m on note.id_matiere = m.id 
    where e.id = 'ET000001' and m.id_semestre = 'SMTR004';