🚀 Minimal API — .NET 9 com JWT e Testes Unitários

API desenvolvida em .NET Minimal API com autenticação JWT, suporte a CORS, documentação Swagger, e testes unitários para o módulo de administrador.
Ideal para estudos, demonstração de boas práticas e aplicações REST simples.

🧩 Funcionalidades principais

✅ Autenticação JWT

🔐 Controle de acesso por roles (Admin, Editor)

🚗 CRUD completo de Veículos

👨‍💼 Gestão de Administradores com login e token

🧪 Testes unitários focados no domínio do Administrador

📖 Swagger UI para documentação automática

🧱 Entity Framework + PostgreSQL

📡 Endpoints principais
🔐 Administradores
Método	Rota	Descrição	Autorização

POST	/administradores/login	Login e geração de token JWT	❌

POST	/administradores	Cria novo administrador	✅ Admin

GET	/administradores	Lista administradores	✅ Admin

GET	/administradores/{id}	Retorna por ID	✅ Admin

🚗 Veículos
Método	Rota	Descrição	Autorização

POST	/veiculos	Cadastra novo veículo	✅ Admin/Editor

GET	/veiculos	Lista veículos	✅ Admin/Editor

GET	/veiculos/{id}	Detalha veículo	✅ Admin/Editor

PUT	/veiculos/{id}	Atualiza veículo	✅ Admin

DELETE	/veiculos/{id}	Remove veículo	✅ Admin


🧑‍💻 Autor

Allan R. R. M.
Estudante de Análise de Sistemas — focado em desenvolvimento .NET e APIs RESTful.

📫 GitHub

📜 Licença

Distribuído sob a licença MIT — veja LICENSE para mais detalhes.
