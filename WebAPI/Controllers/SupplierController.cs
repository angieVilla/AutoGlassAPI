using Microsoft.AspNetCore.Mvc;
namespace AutoGlass;

[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    ISupplierRepository supplierRepository;

    public SupplierController(ISupplierRepository context)
    {
        supplierRepository = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Supplier>> GetSuppliers()
    {
        return Ok(supplierRepository.Get());
    }

    [HttpGet("{code}")]
    public ActionResult<Supplier> GetSupplierByCode(int code)
    {
        var currentSupplier = supplierRepository.GetSupplierByCode(code);
        if (currentSupplier != null) return Ok(currentSupplier);

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Supplier Supplier)
    {
        if (!ModelState.IsValid) return BadRequest("Data incomplete");
        await supplierRepository.Insert(Supplier);
        return Ok();

    }

    [HttpPut("{code}")]
    public async Task<ActionResult<Supplier>> Put(int code, [FromBody] Supplier Supplier)
    {
        if (!ModelState.IsValid) return BadRequest("Data incomplete");

        var currentSupplier = supplierRepository.GetSupplierByCode(code);
        if (currentSupplier == null) return NotFound();

        await supplierRepository.Update(code, Supplier);
        return Ok();

    }

    [HttpDelete("{code}")]
    public async Task<ActionResult> DeleteSupplierByCode(int code)
    {
        var currentSupplier = supplierRepository.GetSupplierByCode(code);
        if (currentSupplier == null) return NotFound();

        await supplierRepository.DeleteByCode(code);
        return Ok();
    }



}
