using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamesRental.Domain.Entity;
using GamesRental.Infra.DB.Context;
using GamesRental.Aplication.Domain;

namespace GamesRental.Controllers
{
    public class RentalsController : Controller
    {
        private readonly IRentalService _rentalService;
        private readonly IGamneService _gamneService;
        private readonly IFriendService _friendService;
        private readonly List<Friend> friends;
        private readonly List<Game> games;

        public RentalsController(IRentalService rentalService ,
            IGamneService gamneService,
            IFriendService friendService)
        {
            _rentalService = rentalService;
            _gamneService = gamneService;
            _friendService = friendService;

            friends = _friendService.GetAllAsync().Result.ToList();
            games = _gamneService.GetAllAsync().Result.ToList();
        }

        // GET: Rentals
        public async Task<IActionResult> Index()
        {
            return View(await _rentalService.GetAllAsync());
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _rentalService.GetByIdAsync(id);

            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            ViewData["FriendId"] = new SelectList(friends, "Id", "Id");
            ViewData["GameId"] = new SelectList(games, "Id", "Id");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FriendId,GameId,Id")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                await _rentalService.AddAsync(rental);
                return RedirectToAction(nameof(Index));
            }
            ViewData["FriendId"] = new SelectList(friends, "Id", "Id", rental.FriendId);
            ViewData["GameId"] = new SelectList(games, "Id", "Id", rental.GameId);
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _rentalService.GetByIdAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            ViewData["FriendId"] = new SelectList(friends, "Id", "Id", rental.FriendId);
            ViewData["GameId"] = new SelectList(games, "Id", "Id", rental.GameId);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("FriendId,GameId,Id")] Rental rental)
        {
            if (id != rental.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _rentalService.UpdateAsync(rental);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FriendId"] = new SelectList(friends, "Id", "Id", rental.FriendId);
            ViewData["GameId"] = new SelectList(games, "Id", "Id", rental.GameId);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _rentalService.RemoveAsync(id);

            if (!rental)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _rentalService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(long id)
        {
            return _rentalService.GetByIdAsync(id) != null ? true : false;
        }
    }
}
