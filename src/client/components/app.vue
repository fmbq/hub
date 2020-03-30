<template>
    <div>
        <header>
            <router-link to="/">
                <h1>FMBQ Hub</h1>
            </router-link>
            <nav>
                <router-link to="/about">About</router-link>
            </nav>
        </header>

        <main>
            <router-view></router-view>
        </main>
    </div>
</template>
