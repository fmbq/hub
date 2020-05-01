import "regenerator-runtime/runtime";

import Vue from 'vue';
import VueMeta from 'vue-meta'
import VueRouter from 'vue-router';
import About from './components/about.vue';
import App from './components/app.vue';
import Home from './components/home.vue';
import Login from './components/login.vue';

Vue.use(VueMeta);
Vue.use(VueRouter);

const router = new VueRouter({
    mode: 'history',
    routes: [
        {
            path: "/",
            component: Home
        },
        {
            path: "/about",
            component: About
        },
        {
            path: "/login",
            component: Login
        }
    ]
});

const app = new Vue({
    metaInfo: {
        titleTemplate(title) {
            return title ? `${title} - FMBQ Hub` : 'FMBQ Hub';
        }
    },
    router,
    render: createElement => createElement(App),
}).$mount('#app');
