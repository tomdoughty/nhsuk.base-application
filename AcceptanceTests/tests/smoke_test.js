Feature('Smoke test');

Scenario('The application renders', (I) => {
  I.amOnPage('/');
  I.see('Welcome', 'h1');
});
