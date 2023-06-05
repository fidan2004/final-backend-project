using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerce_Website.Data;
using Ecommerce_Website.Models;
using WebApplication1.Areas.AdminPanel.ViewModels.Testimonial;

namespace WebApplication1.Areas.AdminPanel.Controllers;

[Area("AdminPanel")]
public class SayingClientsController : Controller
{

    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public SayingClientsController(AppDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _webHostEnvironment = environment;
    }

    public async Task<IActionResult> Index()
    {
        var comment = await _context.SayingClients.ToListAsync();
        return View(comment);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateSayingClientsVM createTestimonialVM)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        if (!createTestimonialVM.Photo.ContentType.Contains("image/"))
        {
            return View();
        }

        if (createTestimonialVM.Photo.Length / 1024 > 5000)
        {
            return View();
        }

        string filename = Guid.NewGuid().ToString() + "___" + createTestimonialVM.Photo.FileName;

        string path = Path.Combine(_webHostEnvironment.WebRootPath, "images/dbphoto", filename);

        using FileStream stream = new(path, FileMode.Create);

        await createTestimonialVM.Photo.CopyToAsync(stream);

        SayingClients comment = new()
        {
            Name = createTestimonialVM.Name,
            Surname = createTestimonialVM.Surname,
            Client = createTestimonialVM.Client,
            Comment = createTestimonialVM.Comment,
            Image = filename,

        };
        await _context.SayingClients.AddAsync(comment);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var comment = await _context.SayingClients.FirstOrDefaultAsync(a => a.Id == id);
        if (comment == null)
        {
            return NotFound();
        }
        return View(comment);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var comment = await _context.SayingClients.FirstOrDefaultAsync(a => a.Id == id);
        if (comment == null) return View();

        string path = Path.Combine(_webHostEnvironment.WebRootPath, "images/dbphoto", comment.Image);

        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);
        }
        _context.SayingClients.Remove(comment);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var updateComment = await _context.SayingClients.FirstOrDefaultAsync(x => x.Id == id);
        if (updateComment == null) return NotFound();

        var updateCommentVM = new UpdateSayingClientsVM()
        {
            Id = updateComment.Id,
            Name = updateComment.Name,
            Surname = updateComment.Surname,
            Client = updateComment.Client,
            Comment = updateComment.Comment,
            Image = updateComment.Image,
        };
        return View(updateCommentVM);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateSayingClientsVM updateCommentVM)
    {
        var updateComment = await _context.SayingClients.FirstOrDefaultAsync(x => x.Id == updateCommentVM.Id);
        if (updateComment == null) return NotFound();

        if (updateCommentVM.Photo != null)
        {
            #region CreateNewImage
            if (!updateCommentVM.Photo.ContentType.Contains("image/"))
            {
                return View();
            }

            if (updateCommentVM.Photo.Length / 1024 > 1000)
            {
                return View();
            }

            string filename = Guid.NewGuid().ToString() + "__" + updateCommentVM.Photo.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "images/dbphoto", filename);

            using FileStream stream = new(path, FileMode.Create);

            await updateCommentVM.Photo.CopyToAsync(stream);

            #endregion

            #region DeleteOldImage

            string oldPath = Path.Combine(_webHostEnvironment.WebRootPath, "images/dbphoto", updateComment.Image);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }

            updateComment.Image = filename;
            #endregion
        }


        updateComment.Name = updateCommentVM.Name;
        updateComment.Surname = updateCommentVM.Surname;
        updateComment.Client = updateCommentVM.Client;
        updateComment.Comment = updateCommentVM.Comment;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    } 
}
