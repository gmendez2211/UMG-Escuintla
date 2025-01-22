CREATE TABLE t_alumnos (carnet varchar(15) NOT NULL, primer_nombre varchar(20) NOT NULL, segundo_nombre varchar(20) NOT NULL, primer_apellido varchar(20) NOT NULL, segundo_apellido varchar(20) NOT NULL, apellido_casada varchar(20) NOT NULL, estado varchar(1) NOT NULL, PRIMARY KEY (carnet));
CREATE TABLE t_asistencia (id_asistencia SERIAL NOT NULL, carnet varchar(15) NOT NULL, fecha_inicio_asistencia timestamp NOT NULL, fecha_fin_asistencia timestamp NOT NULL, estado varchar(1) NOT NULL, PRIMARY KEY (id_asistencia));
CREATE TABLE t_asistencia_curso (id SERIAL NOT NULL, id_asistencia int4 NOT NULL, id_curso varchar(8) NOT NULL, fecha timestamp NOT NULL, estado varchar(1) NOT NULL, PRIMARY KEY (id));
CREATE TABLE t_cursos (id_cursos varchar(8) NOT NULL, nombre_curso varchar(50) NOT NULL, estado varchar(1) NOT NULL, CONSTRAINT id_cursos PRIMARY KEY (id_cursos));
ALTER TABLE t_asistencia_curso ADD CONSTRAINT FKt_asistenc881336 FOREIGN KEY (id_curso) REFERENCES t_cursos (id_cursos);
ALTER TABLE t_asistencia_curso ADD CONSTRAINT FKt_asistenc506340 FOREIGN KEY (id_asistencia) REFERENCES t_asistencia (id_asistencia);
ALTER TABLE t_asistencia ADD CONSTRAINT FKt_asistenc319867 FOREIGN KEY (carnet) REFERENCES t_alumnos (carnet);
