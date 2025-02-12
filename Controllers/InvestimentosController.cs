using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/investimentos")]
public class InvestimentosController : ControllerBase
{
    private static List<Investimento> _investimentos = new List<Investimento>();

    [HttpPost]
    public IActionResult CadastrarInvestimento([FromBody] Investimento novoInvestimento)
    {
        _investimentos.Add(novoInvestimento);
        return CreatedAtAction(nameof(ObterInvestimento), new { id = novoInvestimento.Id }, novoInvestimento);
    }

    [HttpGet("{id}")]
    public IActionResult ObterInvestimento(int id)
    {
        var investimento = _investimentos.FirstOrDefault(i => i.Id == id);
        if (investimento == null)
            return NotFound();

        return Ok(investimento);
    }

    [HttpGet]
    public IActionResult ListarInvestimentos()
    {
        return Ok(_investimentos);
    }
}

public class Investimento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double ValorInicial { get; set; }
    public double RentabilidadeAnual { get; set; } // Ex: 10% = 0.10
}
