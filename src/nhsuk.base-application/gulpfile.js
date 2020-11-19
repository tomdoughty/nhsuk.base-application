const gulp = require('gulp');
const del = require('del');
const sass = require('gulp-sass');
const cleanCss = require('gulp-clean-css');
const webpack = require('webpack-stream');

const inputDir = './wwwroot/src';
const outputDir = './wwwroot/dist';

// Compile SCSS into a single CSS file
function compileCSS() { 
  return gulp.src(`${inputDir}/scss/main.scss`)
    .pipe(sass())
    .on('error', sass.logError)
    .pipe(cleanCss())
    .pipe(gulp.dest(outputDir));
};

// Compile JS file into a single ES5 JS file using Webpack and Babel 
function compileJS() {
  return gulp.src(`${inputDir}/js/main.js`)
    .pipe(webpack({
      mode: 'production',
      module: {
        rules: [
          {
            use: {
              loader: 'babel-loader',
              options: {
                presets: ['@babel/preset-env'],
              },
            },
          },
        ],
      },
      output: {
        filename: 'main.js',
      },
      target: 'web',
    }))
    .pipe(gulp.dest(outputDir));
};

// Copy images
function copyImages() {
  return gulp.src(`${inputDir}/images/**/*`)
    .pipe(gulp.dest(`${outputDir}/images`));
};

// Build function to be used in Gulp tasks
const build = async () => {
  // Clean wwwroot/dist directory
  await  del(outputDir);
  // Compile CSS
  compileCSS();
  // Compile JS
  compileJS();
  // Copy images
  copyImages();
}

// Default task called by running `npm run start`
gulp.task('default', () => {
  build();
  // Watch src CSS and recompile on changes
  gulp.watch(`${inputDir}/scss/**/*.scss`, gulp.series([compileCSS]));
  // Watch src JS and recompile on changes
  gulp.watch(`${inputDir}/js/**/*.js`, gulp.series([compileJS]));
});

gulp.task('build', (done) => {
  build();
  return done();
});
