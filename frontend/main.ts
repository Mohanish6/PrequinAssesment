import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { AppComponent } from './app/app.component';
import { appConfig } from './app/app.config';

// Extend appConfig to include provideHttpClient
const extendedAppConfig = {
  ...appConfig,
  providers: [
    ...(appConfig.providers || []), // Include existing providers if any
    provideHttpClient(),           // Add HttpClient configuration
  ],
};

bootstrapApplication(AppComponent, extendedAppConfig)
  .catch((err) => console.error(err));