import SwaggerClient from "swagger-client";

let client = null;

async function getClient() {
    if (!client) {
        client = await new SwaggerClient("/swagger/v1/swagger.json");
    }

    return client;
}

export default new Proxy({}, {
    get(obj, tag) {
        return new Proxy({}, {
            get(obj, operationId) {
                return async () => {
                    let client = await getClient();
                    return await client.apis[tag][operationId].apply(null, arguments);
                };
            }
        });
    }
});
