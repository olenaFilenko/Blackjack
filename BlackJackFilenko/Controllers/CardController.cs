using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJack.ViewModels.CardServiceViewModel;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Services;
using System.Threading.Tasks;

namespace BlackJackFilenko.Controllers
{
    public class CardController : AsyncController
    {
        private ICardService _cardService;

        public CardController(ICardService cardService) {
            _cardService = cardService;
        }
        
        // GET: Card
        public async Task<ActionResult> Index()
        {
            try
            {
                var cards = await _cardService.GetAllCards();
                return View(cards);
            }
            catch(Exception e)
            {
                return View("Error");
            }            
        }

        [HttpGet]
        public async Task<ActionResult> Add() {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddCardViewModel card)
        {
            try
            {
                await _cardService.Add(card);
                await _cardService.Save();
                return RedirectToAction("Index");
                return View();
                
            }
            catch (Exception e)
            {
                return View("Error");
            }            
        }

        [HttpGet]
        public async Task<ActionResult> Show(int id)
        {
            try
            {
                GetCardByIdViewModel card = await _cardService.GetCardById(id);
                return View(card);
            }
            catch (Exception e)
            {
                return View("Error");
            }            
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                UpdateCardViewModel card = await _cardService.Update(id);
                return View(card);
            }
            catch (Exception e)
            {
                return View("Error");
            }            
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UpdateCardViewModel card)
        {
            try
            {
                await _cardService.Update(card);
                return RedirectToAction("Index");
                return View(card);
            }
            catch (Exception e)
            {
                return View("Error");
            }   

        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id) {
            try
            {
                GetCardByIdViewModel card = await _cardService.GetCardById(id);
                return View(card);
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _cardService.RemoveCard(id);
                return RedirectToAction("Index");
                return View();
            }
            catch (Exception e)
            {
                return View("Error");
            }            
        }
    }
}