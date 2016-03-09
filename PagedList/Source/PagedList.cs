using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PagedList.Source
{
    /// <summary>
    /// Geeric class for paging sources that implement IEnumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T>
    {
        /// <summary>
        /// Size of one page. Default is 10
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Page number currently selected. Default is 1
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// List to be paged
        /// </summary>
        public IEnumerable<T> List { get; set; }
        /// <summary>
        /// Number of total pages
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// Indicates whether the paging should display the prev button
        /// </summary>
        public bool HasPrevPage { get; private set; }
        /// <summary>
        /// Indicates whether the paging should display the next button
        /// </summary>
        public bool HasNextPage { get; private set; }
        /// <summary>
        /// Number of pages that are displayed at the same time. Default is 5.
        /// </summary>
        public int MaxPagesToDisplay { get; set; }
        /// <summary>
        /// Pages that should be displayed now
        /// </summary>
        public int[] PagesDisplayed { get; private set; }

        /// <summary>
        /// Creates a PagedList instance
        /// </summary>
        /// <param name="list">List to be paged</param>
        public PagedList(IEnumerable<T> list) : this(list, 1, 10) { }

        /// <summary>
        /// Creates a PagedList instance
        /// </summary>
        /// <param name="list">List to be paged</param>
        /// <param name="pageNumber">Current page number</param>
        /// <param name="pageSize">Size of one page</param>
        public PagedList(IEnumerable<T> list, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            if (PageNumber < 1)
                PageNumber = 1;
            PageSize = pageSize;
            if (PageSize < 1)
                PageSize = 10;

            List = list;

            MaxPagesToDisplay = 5;

            decimal recordCount = (decimal)List.Count();

            TotalPages = (int)Math.Ceiling(recordCount / PageSize);

            if (MaxPagesToDisplay > TotalPages)
                MaxPagesToDisplay = TotalPages;
            if (PageNumber > TotalPages)
                PageNumber = TotalPages;


            HasNextPage = PageNumber < TotalPages;
            HasPrevPage = PageNumber > 1;

            PagesDisplayed = new int[MaxPagesToDisplay];
            for (int i = 0; i < MaxPagesToDisplay; i++)
            {
                if (PageNumber <= MaxPagesToDisplay)
                    PagesDisplayed[i] = i + 1;
                else
                    PagesDisplayed[i] = PageNumber - MaxPagesToDisplay + i + 1;
            }

        }

        /// <summary>
        /// Replaces the data source with only those data that correspond to the page
        /// </summary>
        /// <param name="pageNumber">Number of the page selected</param>
        /// <returns></returns>
        public void DisplayPage(int pageNumber)
        {
            List = pageNumber > 0 ? List.Skip((PageNumber - 1) * PageSize).Take(PageSize) : List.Take(PageSize);
        }

        /// <summary>
        /// Adds pagination to a PagedList
        /// </summary>
        /// <param name="url">Url to be assigned to the pages(contains a placeholder)</param>
        /// <returns></returns>
        public MvcHtmlString Paginate(string url)
        {
            if (this.TotalPages > 1)
            {
                TagBuilder divTag = new TagBuilder("div");
                divTag.AddCssClass("pager");
                StringBuilder sb = new StringBuilder();

                TagBuilder prevLinkTag = new TagBuilder("a");
                if (this.HasPrevPage)
                    prevLinkTag.MergeAttribute("href", string.Format(url, this.PageNumber - 1));
                TagBuilder prevTag = new TagBuilder("span");
                prevTag.AddCssClass("sp-page");
                prevTag.AddCssClass("sp-page-prev");
                prevTag.InnerHtml = "← ";
                prevLinkTag.InnerHtml = prevTag.ToString();
                sb.Append(prevLinkTag.ToString());

                for (int i = 0, length = this.PagesDisplayed.Length; i < length; i++)
                {
                    TagBuilder pageLinkTag = new TagBuilder("a");
                    pageLinkTag.MergeAttribute("href", string.Format(url, this.PagesDisplayed[i]));
                    TagBuilder pageTag = new TagBuilder("span");
                    pageTag.AddCssClass("sp-page");
                    pageTag.AddCssClass("sp-page-number");
                    if (this.PagesDisplayed[i] == this.PageNumber)
                        pageTag.AddCssClass("sp-page-selected");
                    pageTag.InnerHtml = this.PagesDisplayed[i].ToString();
                    pageLinkTag.InnerHtml = pageTag.ToString();
                    sb.Append(pageLinkTag.ToString());
                }
                TagBuilder nextLinkTag = new TagBuilder("a");
                if (this.HasNextPage)
                    nextLinkTag.MergeAttribute("href", string.Format(url, this.PageNumber + 1));
                TagBuilder nextTag = new TagBuilder("span");
                nextTag.AddCssClass("sp-page");
                nextTag.AddCssClass("sp-page-next");
                nextTag.InnerHtml = " →";
                nextLinkTag.InnerHtml = nextTag.ToString();
                sb.Append(nextLinkTag.ToString());

                divTag.InnerHtml = sb.ToString();
                return MvcHtmlString.Create(divTag.ToString());
            }
            return MvcHtmlString.Create("");
        }
    }
}