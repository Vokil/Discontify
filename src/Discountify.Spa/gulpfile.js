/// <binding BeforeBuild='copy, min' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
concat = require('gulp-concat'),
cssmin = require('gulp-cssmin'),
uglify = require('gulp-uglify');

var paths = {
    webroot: './wwwroot/',
    libroot: './wwwroot/lib/'
};


paths.bootstrapCss = paths.libroot + 'bootstrap/dist/css/bootstrap.css';
paths.sbAdminCss = paths.libroot + 'startbootstrap-sb-admin-2/dist/css/sb-admin-2.css';
paths.fontAwesomeCss = paths.libroot + 'font-awesome/css/font-awesome.css';
paths.morrisCss = paths.libroot + 'morrisjs/morris.css';

paths.jqueryJs = paths.libroot + 'jquery/dist/jquery.js';
paths.raphaelJs = paths.libroot + 'jquery/raphael/raphael.js';
paths.morrisJs = paths.libroot + 'jquery/morrisjs/morris.js';

paths.fonts = paths.libroot + 'font-awesome/fonts/*';

paths.jsDest = paths.webroot + 'js';
paths.cssDest = paths.webroot + 'css';
paths.fontDest = paths.webroot + 'fonts';

gulp.task('min:js', function () {
    return gulp.src([paths.jqueryJs, paths.raphaelJs, paths.morrisJs])
        .pipe(concat(paths.jsDest + '/min/site.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest('.'));
});

gulp.task('copy:js', function () {
    return gulp.src([paths.jqueryJs, paths.raphaelJs, paths.morrisJs])
        .pipe(gulp.dest(paths.jsDest));
});

gulp.task('min:css', function () {
    return gulp.src([paths.bootstrapCss, paths.sbAdminCss, paths.fontAwesomeCss, paths.morrisCss])
        .pipe(concat(paths.cssDest + '/min/site.min.css'))
        .pipe(cssmin())
        .pipe(gulp.dest('.'));
});

gulp.task('copy:css', function () {
    return gulp.src([paths.bootstrapCss, paths.sbAdminCss, paths.fontAwesomeCss, paths.morrisCss])
        .pipe(gulp.dest(paths.cssDest));
});

gulp.task('copy:fonts', function () {
    return gulp.src([paths.fonts])
        .pipe(gulp.dest(paths.fontDest));
});

gulp.task('min', ['min:js', 'min:css']);
gulp.task('copy', ['copy:js', 'copy:css', 'copy:fonts']);