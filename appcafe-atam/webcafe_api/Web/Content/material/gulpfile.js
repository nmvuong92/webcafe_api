var gulp = require('gulp');
var minifyCSS = require('gulp-csso');
var concat = require('gulp-concat');
var sourcemaps = require('gulp-sourcemaps');



gulp.task('css', function(){
  return gulp.src([
      'plugins/bootstrap/css/bootstrap.css',
      'plugins/node-waves/waves.css',
      'plugins/animate-css/animate.css',
      'plugins/morrisjs/morris.css',
      'css/style.css',
      'css/themes/all-themes.css',
  ])
   // .pipe(less())
    .pipe(minifyCSS())
    .pipe(concat('app.min.css'))
    .pipe(gulp.dest('build/css'))
 
});

gulp.task('js', function(){
  return gulp.src([
      'plugins/vue2/vue.min.js',
      'plugins/jquery/jquery.min.js',
      'plugins/bootstrap/js/bootstrap.js',
      'plugins/bootstrap-select/js/bootstrap-select.js',
      'plugins/jquery-slimscroll/jquery.slimscroll.js',
      'plugins/node-waves/waves.js',
      'plugins/jquery-countto/jquery.countTo.js',
      'plugins/raphael/raphael.min.js',
      'plugins/morrisjs/morris.js',
      'plugins/chartjs/Chart.bundle.js',
      'plugins/flot-charts/jquery.flot.js',
      'plugins/flot-charts/jquery.flot.resize.js',
      'plugins/flot-charts/jquery.flot.pie.js',
      'plugins/flot-charts/jquery.flot.categories.js',
      'plugins/flot-charts/jquery.flot.time.js',
      'plugins/jquery-sparkline/jquery.sparkline.js',
      'js/admin.js',
      'js/pages/index.js',
      'js/demo.js'
  ])
    .pipe(sourcemaps.init())
    .pipe(concat('app.min.js'))
    .pipe(sourcemaps.write())
    .pipe(gulp.dest('build/js'))

});

gulp.task('default', ['css', 'js' ]);
