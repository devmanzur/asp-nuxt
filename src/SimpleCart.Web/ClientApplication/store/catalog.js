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
  async loadProducts({ state, commit }) {
    const existingItems = state.products;
    if (existingItems.length > 0) return;

    const response = await this.$axios.$get('catalog');
    if (response.success) {
      commit('setProducts', response.data);
    }
  },
  async loadCategories({ state, commit }) {
    const existingItems = state.categories;
    if (existingItems.length > 0) return;

    const response = await this.$axios.$get('catalog/categories');
    if (response.success) {
      commit('setCategories', response.data);
    }
  },
};
