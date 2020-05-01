<template>
    <div>
        <h1>Seasons</h1>

        <section v-if="errored">
            <p>We're sorry, we're not able to retrieve this information at the moment, please try back later</p>
        </section>

        <section v-else>
            <div v-if="loading">Loading...</div>

            <div v-else>
                <ul>
                    <li v-for="season in seasons" :key="season.id">{{ season.startingYear }} - {{ season.endingYear }}</li>
                </ul>
            </div>
        </section>
    </div>
</template>

<script>
import api from "../api";

export default {
    data() {
        return {
            loading: true,
            errored: false,
            seasons: []
        };
    },

    async mounted() {
        try {
            this.seasons = (await api.seasons.getSeasons()).obj;
            this.loading = false;
        } catch (error) {
            console.log(error);
            this.errored = true;
        }
    }
};
</script>
