// Components
import Header from 'nhsuk-frontend/packages/components/header/header';
import SkipLink from 'nhsuk-frontend/packages/components/skip-link/skip-link';
import Details from 'nhsuk-frontend/packages/components/details/details';
import Radios from 'nhsuk-frontend/packages/components/radios/radios';
import Checkboxes from 'nhsuk-frontend/packages/components/checkboxes/checkboxes';
import FormValidation from './formValidation';

// Polyfills
import 'nhsuk-frontend/packages/polyfills';

// Initialize components
document.addEventListener('DOMContentLoaded', () => {
  Details();
  Header();
  SkipLink();
  Radios();
  Checkboxes();
  FormValidation();
});
