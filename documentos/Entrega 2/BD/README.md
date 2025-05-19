# Modelagem Física do Banco de Dados

Este documento descreve a modelagem física do banco de dados utilizada neste projeto. Foram criadas duas tabelas principais, com base no modelo conceitual previamente definido.

As tabelas foram planejadas para representar dados relacionados a alunos e cursos. Abaixo estão os detalhes de cada uma.


## Tabela: Alunos

Representa os alunos cadastrados no sistema.

| Campo            | Tipo         | Descrição                    |
| ---------------- | ------------ | ---------------------------- |
| ID               | INT (PK)     | Identificador único do aluno |
| NOME             | VARCHAR(100) | Nome completo do aluno       |
| MATRICULA        | VARCHAR(50)  | Número de matrícula (único)  |
| EMAIL            | VARCHAR(100) | E-mail institucional (único) |
| DATA\_NASCIMENTO | DATE         | Data de nascimento do aluno  |
| TELEFONE         | VARCHAR(20)  | Número de telefone com DDD   |
| ENDERECO         | VARCHAR(200) | Endereço completo do aluno   |
| DATA\_CADASTRO   | DATE         | Data de cadastro no sistema  |
| ATIVO            | BOOLEAN      | Indica se o aluno está ativo |


---

# Modelagem Física do Banco de Dados

## Tabelas Implementadas

### 1. USUARIO
| Campo    | Tipo         | Descrição               |
|----------|--------------|-------------------------|
| ID       | INT (PK)     | Identificador único     |
| NOME     | VARCHAR(100) | Nome do usuário         |
| EMAIL    | VARCHAR(100) | E-mail (único)          |
| ENDERECO | VARCHAR(200) | Endereço físico         |
| PLANTA   | VARCHAR(50)  | Localização no edifício |
| TIPO     | VARCHAR(50)  | Tipo de permissão       |

### 2. CASA_INTELIGENTE
| Campo       | Tipo          | Descrição                     |
|-------------|---------------|-------------------------------|
| ID          | INT (PK)      | Identificador único           |
| ESTADO      | VARCHAR(20)   | Status da casa                |
| VALOR       | DECIMAL(10,2) | Valor associado               |
| ID_USUARIO  | INT (FK)      | Usuário que controla a casa   |

### Relacionamentos
- *USUARIO* → Controla → *CASA_INTELIGENTE* (1:N)
- *CASA_INTELIGENTE* → Tem → *DISPOSITIVO* (1:N)
- *USUARIO* → Visualiza → *CASA_INTELIGENTE* (M:N via ACESSO_SERVIDOR)

