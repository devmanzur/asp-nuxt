export const state = () => ({
  products: [],
  categories: [],
});

export const mutations = {
  setProducts(state, content) {
    state.products = content;
  },
  setCategories(state, content) {
    state.categories = content;
  },
};

export const actions = {
  async nuxtServerInit({ commit }, { $axios }) {
    // const getProducts = await this.$axios.$get('catalog');
    // if (getProducts.success) {
    //   commit('setProducts', getProducts.data);
    // }
    // const getCategories = await this.$axios.$get('catalog/categories');
    // if (getCategories.success) {
    //   this.$store.commit('setCategories', getCategories.data);
    // }
  },
};
