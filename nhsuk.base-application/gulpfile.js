const gulp = require('gulp');
const del = require('del');
const sass = require('gulp-sass');
const cleanCss = require('gulp-clean-css');
const webpack = require('webpack-stream');

const inputDir = './wwwroot/src';
const outputDir = './wwwroot/dist';

// Clean wwwroot/dist directory
function cleanDist() {
  return del(outputDir);
};

// Compile SCSS
function compileCSS() { 
  return gulp.src(`${inputDir}/scss/main.scss`)
    .pipe(sass())
    .on('error', sass.logError)
    .pipe(cleanCss())
    .pipe(gulp.dest(outputDir));
};

// Compile JS
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

gulp.task('default', () => {
  // Compile CSS
  compileCSS();
  // Compile JS
  compileJS();
  // Watch src CSS and recompile on changes
  gulp.watch(`${inputDir}/scss/**/*.scss`, gulp.series([compileCSS]));
  // Watch src JS and recompile on changes
  gulp.watch(`${inputDir}/js/**/*.js`, gulp.series([compileJS]));
});

gulp.task('build', (done) => {
  // Clean dist
  cleanDist()
  // Compile CSS
  compileCSS();
  // Compile JS
  compileJS();
  // Finish task with done callback
  return done();
});
