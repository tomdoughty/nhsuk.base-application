// Components
import Header from '../../../node_modules/nhsuk-frontend/packages/components/header/header';
import SkipLink from '../../../node_modules/nhsuk-frontend/packages/components/skip-link/skip-link';
import Details from '../../../node_modules/nhsuk-frontend/packages/components/details/details';
import Radios from '../../../node_modules/nhsuk-frontend/packages/components/radios/radios';
import Checkboxes from '../../../node_modules/nhsuk-frontend/packages/components/checkboxes/checkboxes';

// Polyfills
import '../../../node_modules/nhsuk-frontend/packages/polyfills';

//import '../scss/main.scss';

// Initialize components
document.addEventListener('DOMContentLoaded', () => {
    Details();
    Header();
    SkipLink();
    Radios();
    Checkboxes();
});
