import scrapy


class GithubtrendingrepoSpider(scrapy.Spider):
    name = 'GithubTrendingRepo'
    allowed_domains = ['www.cdicollege.ca']
    start_urls = ['http://www.cdicollege.ca/all-news/about-cdi/cdi-college-largest-post-secondary-ipad-initiative-north-america/']

    def parse(self, response):
      #print("%s : %s : %s" % (response.status, response.url, response.text))
      #title_text = response.xpath('//title[1]/text()')
      #print(title_text.get())
      error_text = response.xpath('//*[@id="error-404"]/text()')
      print(error_text.get())
