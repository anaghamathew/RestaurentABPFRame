import { RestaurentProjectTemplatePage } from './app.po';

describe('RestaurentProject App', function() {
  let page: RestaurentProjectTemplatePage;

  beforeEach(() => {
    page = new RestaurentProjectTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
