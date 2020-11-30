export default () => {
  // Error summary component
  const summary = document.querySelector('.nhsuk-error-summary');
  if (summary) {
    // Focus error summary component if it exists
    summary.focus();
    // Error summary links
    const summaryLinks = document.querySelectorAll('.nhsuk-error-summary__list a');
    // Attach click event to each error summary link
    summaryLinks.forEach((summaryLink) => {
      summaryLink.addEventListener('click', (event) => {
        event.preventDefault();
        // Input component to focus
        const input = document.querySelector(event.target.hash);
        // Focus input component if it exists
        if (input) input.focus();
      });
    });
  }
};
