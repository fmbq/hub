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
import SwaggerClient from "swagger-client";

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
            let client = await new SwaggerClient("/swagger/v1/swagger.json");
            this.seasons = (await client.apis.seasons.getSeasons()).obj;
            console.log(this.seasons);
            this.loading = false;
        } catch (error) {
            console.log(error);
            this.errored = true;
        }
    }
};
</script>
