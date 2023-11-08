using HitachiQA.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiBerkLOB.Source.Driver.SimpleInteractions;
using HitachiQA.Helpers;

namespace BiBerkLOB.Pages.Other
{
    [StaticPageName("Reviews")]
    public sealed class ReviewsPage : IStaticPage
    {
        // Title Banner
        public static Element BannerTitle => new Element(By.XPath("//h1[@data-qa='reviews-page-banner-image-right-header']"));
        public static Element BannerSubHeader => new Element(By.XPath("//h2[@data-qa='reviews-page-banner-image-right-subheader']"));
        public static Element BannerImage => new Element(By.XPath("//img[@data-qa='reviews-page-banner-image-right-image']"));
        
        // Reviews Carousel
        public static Element ReviewCarouselHeader => new Element(By.XPath("//h2[@data-qa='review-carousel-header']"));
        public static Element ReviewCarouselText => new Element(By.XPath("//p[@data-qa='review-carousel-header-text']"));
        
        private static Element ReviewLeftArrow => new Element(By.XPath("//i[@data-qa='review-carousel-arrow-prev']"));
        private static Element ReviewRightArrow => new Element(By.XPath("//i[@data-qa='review-carousel-arrow-next']"));

        private static Element ReviewCarouselReview(int index) => new Element(By.XPath($"(//ul[@data-qa='review-carousel-ul']/li[@data-qa='review-carousel-li'])[{index}]"));
        private static List<CarouselSlide> ReviewCarouselSlides(int min, int max) =>
            Functions.EnumerateIntoList(ReviewCarouselReview, min, max)
                .Select(review => new CarouselSlide(review))
                .ToList();
        public static IStaticInteraction ReviewCarousel => new Carousel(ReviewCarouselSlides(1, 7), ReviewLeftArrow, ReviewRightArrow);
        public static Element ReadAllReviewBtn => new Element(By.XPath("//div[@data-qa='review-carousel-read-all-reviews-button']//button"));

        // Video Reviews
        public static Element VideoCarouselTitle => new Element(By.XPath("//h2[@data-qa='review-carousel-with-video-header']"));
        private static Element VideoLeftArrow => new Element(By.XPath("//i[@data-qa='review-carousel-with-video-previous']"));
        private static Element VideoRightArrow => new Element(By.XPath("//i[@data-qa='review-carousel-with-video-next']"));
        private static Element VideoCarouselReview(int index) => new Element(By.XPath($"(//ul[@data-qa='review-carousel-with-video-ul']/li[@data-qa='review-carousel-with-video-li'])[{index}]"));
        private static Element VideoCarouselVideo(int index) => new Element(By.XPath($"(//ul[@data-qa='review-carousel-with-video-ul']/li[@data-qa='review-carousel-with-video-li']//div[@data-qa='review-carousel-with-video-li-video'])[{index}]"));
        private static List<CarouselSlide> VideoSlides(int min, int max) =>
            Functions.EnumerateIntoList(VideoCarouselReview, min, max)
                .Zip(Functions.EnumerateIntoList(VideoCarouselVideo, min, max), 
                    (review, video) => new CarouselSlide(review, video))
                .ToList();
        public static IStaticInteraction VideoCarousel => new Carousel(VideoSlides(1,7), VideoLeftArrow, VideoRightArrow);

        // All Reviews Modal
        private static Element ModalTitleWithAverageStars => new Element(By.XPath("//div[@data-qa='review-modal-with-ekomi']"));
        private static Element ModalCloseBtn => new Element(By.XPath("//span[@data-qa='review-modal-with-ekomi-modal-close-button']"));
        private static Element ModalSearchAndSortButtons => new Element(By.XPath("//div[@data-qa='review-modal-with-ekomi-search-and-buttons']"));
        private static Element ModalReview(int index) => new Element(By.XPath($"//div[@data-qa='review-modal-with-ekomi-reviews-{index}']"));
        public static IStaticInteraction AllReviewsModal => new ReviewsModal(ReadAllReviewBtn, ModalCloseBtn, ModalTitleWithAverageStars, ModalSearchAndSortButtons, Functions.EnumerateIntoList(ModalReview, 0, 199));
    }
}