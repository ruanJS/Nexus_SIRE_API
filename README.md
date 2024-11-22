
# SIRE API - Sistema de Registro e Gestão de Energia

## Descrição do Projeto
O SIRE API é uma aplicação backend desenvolvida em .NET Core com o objetivo de gerenciar dispositivos, consumos e relatórios relacionados a sistemas de energia. Este projeto adota uma arquitetura limpa e modular, organizada em camadas (Presentation, Application, Domain, Infrastructure e Tests).


---

### Funcionalidades Principais
- Cadastro e consulta de dispositivos.
- Registro e análise de consumo.
- Geração de relatórios personalizados.
- Testes unitários para validação de serviços, controladores e repositórios.
---

## Tecnologias Utilizadas
- **Linguagem**: C# (.NET Core 6)
- **Banco de Dados**: SQL Server
- **Framework de Testes**: xUnit
- **Mocking**: Moq
- **ORM**: Entity Framework Core

---

## **Estrutura do Projeto**

```
SIRE_API/
├── Controllers/
├── Data/
├── Models/
├── Repositories/
├── Services/
├── DTOs/
├── Interfaces/
├── SIRE_API.csproj
└── Program.cs

```

### **Descrição das Pastas**

### Camadas
1. **Presentation**: Contém os controladores da API (Controllers).
2. **Application**: Inclui os serviços de aplicação e os DTOs para transferência de dados.
3. **Domain**: Define as entidades e interfaces que representam o núcleo do sistema.
4. **Infrastructure**: Implementa a persistência de dados e interações com o banco de dados.
5. **Tests**: Abrange os testes unitários organizados por camadas.
- **Tests/**: Diretório para testes automatizados (unitários e de integração).
- **Logs/**: Contém os arquivos gerados durante a execução do sistema.
- **Docs/**: Armazena arquivos de documentação adicional, como diagramas e arquitetura do projeto.
---

## **Configuração do Projeto**

### **Pré-requisitos**
1. **.NET SDK** instalado (6.0 ou superior).
2. **SQL Server** configurado e em execução.
3. Um editor de código como **Visual Studio** ou **Visual Studio Code**.

### **Configuração do Banco de Dados**
Certifique-se de ter um banco de dados SQL Server configurado e crie o esquema `RM551096` no banco. As tabelas serão criadas automaticamente com o Entity Framework.

### **String de Conexão**
Atualize a string de conexão no método `UseSqlServer` no arquivo `Program.cs`:

```csharp
var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    .UseSqlServer("SuaStringDeConexaoAqui") // Substitua pela string de conexão do seu banco
    .Options;
```

---

## **Como Executar**

1. Clone este repositório:
   ```bash
   git clone https://github.com/seu-usuario/sire-api.git
   cd sire-api
   ```

2. Restaure os pacotes:
   ```bash
   dotnet restore
   ```

3. Compile o projeto:
   ```bash
   dotnet build
   ```

4. Execute a aplicação:
   ```bash
   dotnet run
   ```

---

## **Exemplo de Uso**

Após a execução, a aplicação tentará acessar a tabela `TB_DISPOSITIVO` e buscar o primeiro dispositivo cadastrado. Certifique-se de que há registros inseridos previamente no banco de dados para testar esta funcionalidade.

Exemplo de saída no console:
```
Dispositivo encontrado: Sensor de Temperatura
```

---

## **Contribuindo**

1. Faça um fork deste repositório.
2. Crie uma branch para sua feature:
   ```bash
   git checkout -b minha-feature
   ```
3. Faça commit das suas alterações:
   ```bash
   git commit -m "Adiciona nova feature"
   ```
4. Envie para o repositório remoto:
   ```bash
   git push origin minha-feature
   ```
5. Abra um pull request.

---

## Equipe
- **Geovana Ribeiro Domingos Silva** - RM99646  
- **Leonardo Camargo Lucena** - RM552537  
- **Nathan Nunes Calsonari** - RM552539  
- **Ana Beatriz Bento Silva** - RM552536  
- **Ruan Guedes de Campos** - RM551096  

---
## **Licença**

Este projeto está licenciado sob a [MIT License](https://opensource.org/licenses/MIT).
