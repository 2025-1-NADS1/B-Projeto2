# Modelagem Física do Banco de Dados

Este documento descreve a modelagem física do banco de dados utilizada neste projeto. Foram criadas duas tabelas principais, com base no modelo conceitual previamente definido.

As tabelas foram planejadas para representar dados relacionados a alunos e cursos. Abaixo estão os detalhes de cada uma.


## Tabela: Alunos

Representa os alunos cadastrados no sistema.

- **id**: número inteiro, chave primária (identificador único de cada aluno)
- **nome**: texto, nome completo do aluno
- **matricula**: texto, número de matrícula (valor único)
- **email**: texto, e-mail institucional do aluno
- **data_nascimento**: data, data de nascimento do aluno
- **telefone**: texto, número de telefone com DDD
- **endereco**: texto, endereço completo do aluno
- **data_cadastro**: data, data em que o aluno foi cadastrado no sistema
- **ativo**: booleano, indica se o aluno está ativo ou não

---

## Tabela: Cursos

Representa os cursos oferecidos pela instituição.

- **id**: número inteiro, chave primária (identificador único de cada curso)
- **nome**: texto, nome do curso
- **descricao**: texto, descrição resumida do curso
- **carga_horaria**: número inteiro, carga horária total do curso em horas
- **nivel**: texto, nível do curso (ex: Técnico, Graduação, Pós-Graduação)
- **modalidade**: texto, modalidade do curso (ex: Presencial, EAD, Híbrido)
- **data_inicio**: data, data de início da próxima turma
- **vagas**: número inteiro, quantidade total de vagas oferecidas
- **ativo**: booleano, indica se o curso está ativo para novas matrículas
