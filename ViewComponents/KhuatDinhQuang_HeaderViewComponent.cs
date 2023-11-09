using KhuatDinhQuang_211200865.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace KhuatDinhQuang_211200865.ViewComponents
{
	public class KhuatDinhQuang_HeaderViewComponent:ViewComponent
	{
		private readonly QLHangHoaContext _context;
		private List<LoaiHang> loaiHangs;

		public KhuatDinhQuang_HeaderViewComponent(QLHangHoaContext context)
		{
			_context = context;	
			loaiHangs=_context.LoaiHangs.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("KhuatDinhQuang_Header",loaiHangs);
		}
	}
}
