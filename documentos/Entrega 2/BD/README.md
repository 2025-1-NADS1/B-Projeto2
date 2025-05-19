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

