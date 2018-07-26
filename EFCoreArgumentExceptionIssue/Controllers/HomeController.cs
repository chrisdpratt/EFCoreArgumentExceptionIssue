using EFCoreArgumentExceptionIssue.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EFCoreArgumentExceptionIssue.Controllers
{
    public class HomeController : Controller
    {
        protected readonly FooContext _context;
        protected readonly ILogger _logger;

        public HomeController(FooContext context, ILoggerFactory loggerFactory)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = (loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory))).CreateLogger(GetType());
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
        {
            var foos = await _context.Foos
                .OrderByDescending(x => x.Created)
                .AsNoTracking()
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return View(foos);
        }
    }
}
