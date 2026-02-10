namespace BuilderPattern
{
    public class BuilderPattern
    {
        public sealed class SqlCommandResult
        {
            public string Sql { get; }
            public IReadOnlyDictionary<string, object> Parameters { get; }

            public SqlCommandResult(
                string sql,
                IDictionary<string, object> parameters)
            {
                Sql = sql;
                Parameters = new Dictionary<string, object>(parameters);
            }
        }

        public interface ISqlBuilder
        {
            SqlCommandResult Build();
        }

        public sealed class InsertSqlBuilder : ISqlBuilder
        {
            private readonly string _tabela;
            private readonly List<string> _colunas = new();
            private readonly List<object> _valores = new();
            private readonly Dictionary<string, object> _parametros = new();

            private string _iteracao = "0";

            private InsertSqlBuilder(string tabela)
            {
                _tabela = tabela;
            }

            public static InsertSqlBuilder Create(string tabela)
            {
                if (string.IsNullOrWhiteSpace(tabela))
                    throw new ArgumentException("Tabela inválida.", nameof(tabela));

                return new InsertSqlBuilder(tabela);
            }

            public InsertSqlBuilder WithColumns(params string[] colunas)
            {
                _colunas.AddRange(colunas);
                return this;
            }

            public InsertSqlBuilder WithValues(params object[] valores)
            {
                _valores.AddRange(valores);
                return this;
            }

            public InsertSqlBuilder WithIteration(string iteracao)
            {
                _iteracao = iteracao;
                return this;
            }

            public SqlCommandResult Build()
            {
                Validar();

                var colunasConcat = string.Join(", ", _colunas);
                var parametros = string.Join(
                    ", ",
                    _colunas.Select(c => $"@{c}_{_iteracao}")
                );

                string sql =
                    $"INSERT INTO {_tabela} ({colunasConcat}) VALUES ({parametros});";

                for (int i = 0; i < _colunas.Count; i++)
                {
                    string nomeParametro = $"{_colunas[i]}_{_iteracao}";
                    _parametros[nomeParametro] = _valores[i];
                }

                return new SqlCommandResult(sql, _parametros);
            }

            private void Validar()
            {
                if (_colunas.Count == 0)
                    throw new InvalidOperationException("Nenhuma coluna informada.");

                if (_colunas.Count != _valores.Count)
                    throw new InvalidOperationException(
                        "Quantidade de colunas e valores deve ser igual.");
            }
        }

        /*
            var result = InsertSqlBuilder
                .Create("Clientes")
                .WithColumns("Id", "Nome", "Saldo")
                .WithValues(1, "João", 1500m)
                .WithIteration("0")
                .Build();

                    Console.WriteLine(result.Sql);

            foreach (var param in result.Parameters)
            {
                Console.WriteLine($"{param.Key} = {param.Value}");
            }
        */

}
}
